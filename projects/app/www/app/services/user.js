angular.module('cheping.services.user', [
    'cheping.services'
])
    .service('UserService', function($http, URLS, AuthService, CacheService) {
        var service = this;

        var currentUser = {};

        service.getCurrentUser = function() {
            service.getUserInfo();
            return currentUser;
        };

        service.getUserInfo = function() {
            return $http.get(URLS.USER.GETINFO)
                .then(function(result) {
                    currentUser = result.data;
                    return currentUser;
                });
        };

        service.login = function(loginName, password) {
            return $http.post(URLS.USER.SIGNIN, {
                loginName: loginName,
                password: password
            })
                .then(function(result) {
                    AuthService.setToken(result.data.result);
                }).then(function(result) {
                    service.getUserInfo();
                });
        };

        service.clear = function() {
            currentUser = {};
            AuthService.clearToken();
        };
    });
