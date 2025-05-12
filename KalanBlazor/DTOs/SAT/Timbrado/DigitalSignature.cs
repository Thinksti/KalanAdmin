using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace KalanBlazor.DTOs.SAT.Timbrado;

public class DigitalSignature
{
	public static RSACryptoServiceProvider DecodePrivateKeyInfo(byte[] encpkcs8, string pPassword)
	{
		byte[] oiDpkcs5Pbes2 = new byte[11]
		{
			6, 9, 42, 134, 72, 134, 247, 13, 1, 5,
			13
		};
		byte[] oiDpkcs5Pbkdf2 = new byte[11]
		{
			6, 9, 42, 134, 72, 134, 247, 13, 1, 5,
			12
		};
		byte[] oiDdesEde3Cbc = new byte[10] { 6, 8, 42, 134, 72, 134, 247, 13, 3, 7 };
		BinaryReader binr = new BinaryReader(new MemoryStream(encpkcs8));
		try
		{
			switch (binr.ReadUInt16())
			{
			case 33072:
				binr.ReadByte();
				break;
			case 33328:
				binr.ReadInt16();
				break;
			default:
				return null;
			}
			switch (binr.ReadUInt16())
			{
			case 33072:
				binr.ReadByte();
				break;
			case 33328:
				binr.ReadInt16();
				break;
			}
			if (!CompareBytearrays(binr.ReadBytes(11), oiDpkcs5Pbes2))
			{
				return null;
			}
			switch (binr.ReadUInt16())
			{
			case 33072:
				binr.ReadByte();
				break;
			case 33328:
				binr.ReadInt16();
				break;
			}
			switch (binr.ReadUInt16())
			{
			case 33072:
				binr.ReadByte();
				break;
			case 33328:
				binr.ReadInt16();
				break;
			}
			if (!CompareBytearrays(binr.ReadBytes(11), oiDpkcs5Pbkdf2))
			{
				return null;
			}
			switch (binr.ReadUInt16())
			{
			case 33072:
				binr.ReadByte();
				break;
			case 33328:
				binr.ReadInt16();
				break;
			}
			byte bt = binr.ReadByte();
			if (bt != 4)
			{
				return null;
			}
			int saltsize = binr.ReadByte();
			byte[] salt = binr.ReadBytes(saltsize);
			bt = binr.ReadByte();
			if (bt != 2)
			{
				return null;
			}
			int iterations;
			switch (binr.ReadByte())
			{
			case 1:
				iterations = binr.ReadByte();
				break;
			case 2:
				iterations = 256 * binr.ReadByte() + binr.ReadByte();
				break;
			default:
				return null;
			}
			switch (binr.ReadUInt16())
			{
			case 33072:
				binr.ReadByte();
				break;
			case 33328:
				binr.ReadInt16();
				break;
			}
			if (!CompareBytearrays(binr.ReadBytes(10), oiDdesEde3Cbc))
			{
				return null;
			}
			bt = binr.ReadByte();
			if (bt != 4)
			{
				return null;
			}
			int ivsize = binr.ReadByte();
			byte[] iv = binr.ReadBytes(ivsize);
			bt = binr.ReadByte();
			if (bt != 4)
			{
				return null;
			}
			bt = binr.ReadByte();
			byte[] encryptedpkcs8 = binr.ReadBytes(bt switch
			{
				129 => binr.ReadByte(), 
				130 => 256 * binr.ReadByte() + binr.ReadByte(), 
				_ => bt, 
			});
			SecureString secpswd = new SecureString();
			foreach (char c in pPassword)
			{
				secpswd.AppendChar(c);
			}
			byte[] pkcs8 = DecryptPbdk2(encryptedpkcs8, salt, iv, secpswd, iterations);
			if (pkcs8 == null)
			{
				return null;
			}
			return DecodePrivateKeyInfo(pkcs8);
		}
		catch (Exception)
		{
			return null;
		}
		finally
		{
			binr.Close();
		}
	}

	public static RSACryptoServiceProvider DecodePrivateKeyInfo(byte[] pkcs8)
	{
		byte[] seqOid = new byte[15]
		{
			48, 13, 6, 9, 42, 134, 72, 134, 247, 13,
			1, 1, 1, 5, 0
		};
		MemoryStream mem = new MemoryStream(pkcs8);
		int lenstream = (int)mem.Length;
		BinaryReader binr = new BinaryReader(mem);
		try
		{
			switch (binr.ReadUInt16())
			{
			case 33072:
				binr.ReadByte();
				break;
			case 33328:
				binr.ReadInt16();
				break;
			default:
				return null;
			}
			byte bt = binr.ReadByte();
			if (bt != 2)
			{
				return null;
			}
			ushort twobytes = binr.ReadUInt16();
			if (twobytes != 1)
			{
				return null;
			}
			if (!CompareBytearrays(binr.ReadBytes(15), seqOid))
			{
				return null;
			}
			bt = binr.ReadByte();
			if (bt != 4)
			{
				return null;
			}
			switch (binr.ReadByte())
			{
			case 129:
				binr.ReadByte();
				break;
			case 130:
				binr.ReadUInt16();
				break;
			}
			return DecodeRsaPrivateKey(binr.ReadBytes((int)(lenstream - mem.Position)));
		}
		catch (Exception)
		{
			return null;
		}
		finally
		{
			binr.Close();
		}
	}

	public static RSACryptoServiceProvider DecodeRsaPrivateKey(byte[] privkey)
	{
		BinaryReader binr = new BinaryReader(new MemoryStream(privkey));
		try
		{
			switch (binr.ReadUInt16())
			{
			case 33072:
				binr.ReadByte();
				break;
			case 33328:
				binr.ReadInt16();
				break;
			default:
				return null;
			}
			ushort twobytes = binr.ReadUInt16();
			if (twobytes != 258)
			{
				return null;
			}
			if (binr.ReadByte() != 0)
			{
				return null;
			}
			int elems = GetIntegerSize(binr);
			byte[] modulus = binr.ReadBytes(elems);
			elems = GetIntegerSize(binr);
			byte[] e = binr.ReadBytes(elems);
			elems = GetIntegerSize(binr);
			byte[] d = binr.ReadBytes(elems);
			elems = GetIntegerSize(binr);
			byte[] p = binr.ReadBytes(elems);
			elems = GetIntegerSize(binr);
			byte[] q = binr.ReadBytes(elems);
			elems = GetIntegerSize(binr);
			byte[] dp = binr.ReadBytes(elems);
			elems = GetIntegerSize(binr);
			byte[] dq = binr.ReadBytes(elems);
			elems = GetIntegerSize(binr);
			byte[] iq = binr.ReadBytes(elems);
			Console.WriteLine("showing components ..");
			RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider();
			RSAParameters rsAparams = new RSAParameters
			{
				Modulus = modulus,
				Exponent = e,
				D = d,
				P = p,
				Q = q,
				DP = dp,
				DQ = dq,
				InverseQ = iq
			};
			rSACryptoServiceProvider.ImportParameters(rsAparams);
			return rSACryptoServiceProvider;
		}
		catch (Exception)
		{
			return null;
		}
		finally
		{
			binr.Close();
		}
	}

	public static byte[] DecryptPbdk2(byte[] edata, byte[] salt, byte[] iv, SecureString secpswd, int iterations)
	{
		byte[] psbytes = new byte[secpswd.Length];
		nint num = Marshal.SecureStringToGlobalAllocAnsi(secpswd);
		Marshal.Copy(num, psbytes, 0, psbytes.Length);
		Marshal.ZeroFreeGlobalAllocAnsi(num);
		try
		{
			Rfc2898DeriveBytes kd = new Rfc2898DeriveBytes(psbytes, salt, iterations);
			TripleDES decAlg = TripleDES.Create();
			decAlg.Padding = PaddingMode.Zeros;
			decAlg.Key = kd.GetBytes(24);
			decAlg.IV = iv;
			MemoryStream memstr = new MemoryStream();
			using (CryptoStream decrypt = new CryptoStream(memstr, decAlg.CreateDecryptor(), CryptoStreamMode.Write))
			{
				decrypt.Write(edata, 0, edata.Length);
				decrypt.FlushFinalBlock();
				decrypt.Flush();
				decrypt.Close();
			}
			return memstr.ToArray();
		}
		catch (Exception e)
		{
			Console.WriteLine("Problem decrypting: {0}", e.Message);
			return null;
		}
	}

	public static void CertificateData(string pCerFile, out string certificate, out string certificateNumber, out string fechaExpiracion)
	{
		X509Certificate2 cert = new X509Certificate2(pCerFile);
		byte[] strcert = cert.GetRawCertData();
		certificate = Convert.ToBase64String(strcert);
		strcert = cert.GetSerialNumber();
		certificateNumber = cert.NotBefore.ToString();
		fechaExpiracion = cert.NotAfter.ToString();
	}

	public void CertificateData(byte[] pCerBytes, out string certificate, out string certificateNumber, out string fechaExpiracion)
	{
		X509Certificate2 cert = new X509Certificate2(pCerBytes);
		byte[] strcert = cert.GetRawCertData();
		certificate = Convert.ToBase64String(strcert);
		strcert = cert.GetSerialNumber();
		certificateNumber = Reverse(Encoding.UTF8.GetString(strcert));
		fechaExpiracion = cert.GetExpirationDateString();
	}

	public static RSACryptoServiceProvider OpenKeyFile(string filename, string pPassword)
	{
		byte[] keyblob = GetFileBytes(filename);
		if (keyblob == null)
		{
			return null;
		}
		RSACryptoServiceProvider rsa = DecodePrivateKeyInfo(keyblob, pPassword);
		if (rsa != null)
		{
			return rsa;
		}
		return null;
	}

	public static RSACryptoServiceProvider OpenKeyFile(byte[] bytes, string pPassword)
	{
		RSACryptoServiceProvider rsa = DecodePrivateKeyInfo(bytes, pPassword);
		if (rsa != null)
		{
			return rsa;
		}
		return null;
	}

	public string Reverse(string original)
	{
		string reverse = "";
		for (int i = original.Length - 1; i >= 0; i--)
		{
			reverse += original.Substring(i, 1);
		}
		return reverse;
	}

	public static string SignString(string pKeyFile, string pPassword, string originalString)
	{
		string signedString = "";
		if (!File.Exists(pKeyFile))
		{
			return ".key file does not exist " + pKeyFile;
		}
		RSACryptoServiceProvider rsa = OpenKeyFile(pKeyFile, pPassword);
		if (rsa != null)
		{
			byte[] co = Encoding.UTF8.GetBytes(originalString);
			signedString = Convert.ToBase64String(rsa.SignData(co, new SHA1CryptoServiceProvider()));
		}
		return signedString;
	}

	public static string SignStringSHA256(string pKeyFile, string pPassword, string originalString)
	{
		string signedString = "";
		if (!File.Exists(pKeyFile))
		{
			return ".key file does not exist " + pKeyFile;
		}
		RSACryptoServiceProvider rsa = OpenKeyFile(pKeyFile, pPassword);
		if (rsa != null)
		{
			byte[] co = Encoding.UTF8.GetBytes(originalString);
			signedString = Convert.ToBase64String(rsa.SignData(co, new SHA256CryptoServiceProvider()));
		}
		return signedString;
	}

	public static string SignStringSHA256(byte[] ByteKeys, string pPassword, string originalString)
	{
		string signedString = "";
		RSACryptoServiceProvider rsa = OpenKeyFile(ByteKeys, pPassword);
		if (rsa != null)
		{
			byte[] co = Encoding.UTF8.GetBytes(originalString);
			signedString = Convert.ToBase64String(rsa.SignData(co, new SHA256CryptoServiceProvider()));
		}
		return signedString;
	}
	public static bool ContraseñaValida(byte[] ByteKeys, string pPassword)
	{
		string signedString = "";
		RSACryptoServiceProvider rsa = OpenKeyFile(ByteKeys, pPassword);
		if (rsa != null)
		{
			return true;
		}
		return false;
	}

	public string SignString(byte[] pKeyBytes, string pPassword, string originalString)
	{
		string signedString = "";
		RSACryptoServiceProvider rsa = OpenKeyFile(pKeyBytes, pPassword);
		if (rsa != null)
		{
			byte[] co = Encoding.UTF8.GetBytes(originalString);
			signedString = Convert.ToBase64String(rsa.SignData(co, new SHA1CryptoServiceProvider()));
		}
		return signedString;
	}

	private static bool CompareBytearrays(byte[] a, byte[] b)
	{
		if (a.Length != b.Length)
		{
			return false;
		}
		int i = 0;
		for (int j = 0; j < a.Length; j++)
		{
			if (a[j] != b[i])
			{
				return false;
			}
			i++;
		}
		return true;
	}

	private static byte[] GetFileBytes(string filename)
	{
		if (!File.Exists(filename))
		{
			return null;
		}
		FileStream fileStream = new FileStream(filename, FileMode.Open);
		int datalen = (int)fileStream.Length;
		byte[] filebytes = new byte[datalen];
		fileStream.Seek(0L, SeekOrigin.Begin);
		fileStream.Read(filebytes, 0, datalen);
		fileStream.Close();
		return filebytes;
	}

	private static int GetIntegerSize(BinaryReader binr)
	{
		byte bt = binr.ReadByte();
		if (bt != 2)
		{
			return 0;
		}
		bt = binr.ReadByte();
		int count;
		switch (bt)
		{
		case 129:
			count = binr.ReadByte();
			break;
		case 130:
		{
			byte highbyte = binr.ReadByte();
			byte lowbyte = binr.ReadByte();
			count = BitConverter.ToInt32(new byte[4] { lowbyte, highbyte, 0, 0 }, 0);
			break;
		}
		default:
			count = bt;
			break;
		}
		while (binr.ReadByte() == 0)
		{
			count--;
		}
		binr.BaseStream.Seek(-1L, SeekOrigin.Current);
		return count;
	}
}
