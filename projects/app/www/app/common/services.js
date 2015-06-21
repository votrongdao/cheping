angular.module('cheping.services', [
    'angular-cache'
])
    .service('AuthService', function(CacheService) {
        var service = this;
        var tokenStorage = CacheService.get('authTokenCache');

        service.clearToken = function() {
            tokenStorage.put('auth', '');
        };

        service.getToken = function() {
            return tokenStorage.get('auth') || '';
        };

        service.setToken = function(newToken) {
            if (newToken) {
                tokenStorage.put('auth', newToken);
            }
        };
    })
    .service('CacheService', function(CacheFactory) {
        var service = this;

        CacheFactory('authTokenCache', {
            maxAge: 24 * 60 * 60 * 1000,
            deleteOnExpire: 'aggressive',
            storageMode: 'localStorage'
        });

        CacheFactory('caseCache', {
            maxAge: 5 * 1000,
            deleteOnExpire: 'aggressive',
            storageMode: 'memory'
        });

        CacheFactory('userCache', {
            maxAge: 5 * 1000,
            deleteOnExpire: 'aggressive',
            storageMode: 'memory'
        });

        service.get = function(cacheName, maxAge) {
            maxAge = maxAge || 60 * 1000;

            if (!CacheFactory.get(cacheName)) {
                CacheFactory(cacheName, {
                    maxAge: maxAge,
                    deleteOnExpire: 'aggressive',
                    storageMode: 'localStorage'
                });
            }

            return CacheFactory.get(cacheName);
        };
    })
    .service('ConfigService', function($http, $q, URLS, CacheService) {
        var service = this;

        service.getColors = function() {
            return [{
                colorId: 1,
                colorName: '银灰色',
                colorCode: '#c0c0c0'
            }, {
                colorId: 2,
                colorName: '浅灰色',
                colorCode: '#d3d3d3'
            }, {
                colorId: 3,
                colorName: '白色',
                colorCode: '#c0c0c0'
            }, {
                colorId: 4,
                colorName: '象牙白色',
                colorCode: '#fafff0'
            }, {
                colorId: 5,
                colorName: '黑色',
                colorCode: '#000000'
            }, {
                colorId: 6,
                colorName: '红色',
                colorCode: '#ff0000'
            }, {
                colorId: 7,
                colorName: '深红色',
                colorCode: '#cc0000'
            }, {
                colorId: 8,
                colorName: '粉红色',
                colorCode: '#ff33ff'
            }, {
                colorId: 9,
                colorName: '赭石红色',
                colorCode: '#660033'
            }, {
                colorId: 10,
                colorName: '蓝色',
                colorCode: '#0000ff'
            }, {
                colorId: 11,
                colorName: '天蓝色',
                colorCode: '#87ceeb'
            }, {
                colorId: 12,
                colorName: '深蓝色',
                colorCode: '#0000cc'
            }, {
                colorId: 13,
                colorName: '天蓝色',
                colorCode: '#87ceeb'
            }, {
                colorId: 14,
                colorName: '深蓝色',
                colorCode: '#0000cc'
            }, {
                colorId: 15,
                colorName: '黄色',
                colorCode: '#ffff00'
            }, {
                colorId: 16,
                colorName: '金黄色',
                colorCode: '#ffcc00'
            }, {
                colorId: 17,
                colorName: '沙漠黄色',
                colorCode: '#cccc00'
            }, {
                colorId: 18,
                colorName: '绿色',
                colorCode: '#00ff00'
            }, {
                colorId: 19,
                colorName: '浅绿色',
                colorCode: '#66ff00'
            }, {
                colorId: 20,
                colorName: '嫩绿色',
                colorCode: '#33ff00'
            }, {
                colorId: 21,
                colorName: '墨绿色',
                colorCode: '#006600'
            }, {
                colorId: 22,
                colorName: '橙色',
                colorCode: '#ff9900'
            }
            ]
        }

    })
    .service('UtilityService', function($state, $ionicPopup, $timeout, $cordovaInAppBrowser) {
        var service = this;

        /**
         * Matcher.
         */

        var matcher = /^(?:\w+:)?\/\/([^\s\.]+\.\S{2}|localhost[:?\d]*)\S*$/;

        /**
         * Loosely validate a URL `string`.
         *
         * @param {String} string
         * @return {Boolean}
         */

        function isUrl(string) {
            return matcher.test(string);
        }

        function open(url) {
            if (service.isUrl(url)) {
                $cordovaInAppBrowser.open(url, '_system');
            } else {
                $state.go(url);
            }
        }

        function showAlert(text) {
            var alertPopup = $ionicPopup.alert({
                title: '提示信息',
                template: text
            });

            $timeout(function() {
                alertPopup.close();
            }, 2000);
        }

        service.isUrl = isUrl;
        service.open = open;
        service.showAlert = showAlert;
    });