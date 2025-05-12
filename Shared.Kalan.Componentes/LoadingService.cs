namespace Shared.Kalan.Componentes
{
    public class LoadingService : IDisposable
    {
        public event Func<Task> OnChangeAsync;
        private bool isLoading = false;

        public string Etiqueta
        {
            get
            {
                return _Etiqueta;
            }
            set
            {
                _Etiqueta = value;
                NotifyStateChanged();
            }
        }
        private string _Etiqueta;
        private bool disposedValue;

        public bool IsLoading
        {
            get { return isLoading; }
            set
            {
                isLoading = value;
                NotifyStateChanged().GetAwaiter();
                if (IsLoading == false)
                {
                    Etiqueta = string.Empty;
                }
            }
        }
        private async Task NotifyStateChanged()
        {
            if (OnChangeAsync != null)
            {
                await OnChangeAsync.Invoke();
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
