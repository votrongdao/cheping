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
        tokenStorage.set('auth', newToken);
      }
    };
  })
  .service('CacheService', function(CacheFactory) {
    var service = this;

    CacheFactory('authTokenCache', {
      maxAge: 365 * 24 * 60 * 60 * 1000,
      deleteOnExpire: 'aggressive',
      storageMode: 'localStorage'
    });

    CacheFactory('userCache', {
      maxAge: 10 * 1000,
      deleteOnExpire: 'aggressive',
      storageMode: 'localStorage'
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