var CACHE_VERSION = 'v1';
self.addEventListener('install', function (event) {
    self.skipWaiting();
});
self.addEventListener('activate', function (event) {
    event.waitUntil(
        caches.keys().then(function (cacheNames) {
            return Promise.all(
                cacheNames.map(function (cacheName) {
                    if (cacheName !== CACHE_VERSION) {
                        return caches.delete(cacheName);
                    }
                })
            );
        }).then(function () {
            return self.clients.claim();
        })
    );
});
self.addEventListener('fetch', event => {
    var request = event.request;
    var url = new URL(request.url);

    var shouldCacheRequest = true;

    if (shouldCacheRequest) {
        event.respondWith(
            caches.match(request).then(function (response) {
                return response || fetch(request);
            })
        );
    } else {
        event.respondWith(fetch(request));
    }
});