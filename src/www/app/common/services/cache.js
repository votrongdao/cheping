angular.module('cheping.services.cache', [
    'angular-cache'
])
    .service('ChepingCacheService', function(CacheFactory) {
        var service = this;

        var cache = CacheFactory('storage', {
            maxAge: 365 * 24 * 60 * 60 * 1000,
            cacheFlushInterval: 60 * 60 * 1000,
            deleteOnExpire: 'aggressive',
            storageMode: 'localStorage'
        });

        cache.put('orders', []);

        service.get = function(cacheName, maxAge) {
            maxAge = maxAge || 60 * 1000;

            if (!CacheFactory.get(cacheName)) {
                CacheFactory(cacheName, {
                    maxAge: maxAge,
                    cacheFlushInterval: 60 * 60 * 1000,
                    deleteOnExpire: 'aggressive',
                    storageMode: 'localStorage'
                });
            }

            return CacheFactory.get(cacheName);
        };
    });