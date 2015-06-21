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
            return $http.get(URLS.USER.GETINFO, {
                cache: CacheService.get('userCache')
            }).then(function(result) {
                currentUser = result.data;
                return currentUser;
            });
        };

        service.login = function(loginName, password, AuthService) {
            return $http.post(URLS.USER.SIGNIN, {
                loginName: loginName,
                password: password
            })
                .then(function(result) {
                    AuthService.setToken(result.data.result);
                });
        };
    });
