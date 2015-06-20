angular.module('cheping.interceptors', [
    'cheping.services'
])
    .factory('globalInterceptor', function($q, $log, $rootScope, $timeout, $injector) {
        var authService = $injector.get('AuthService');

        return {
            'request': function(config) {
                config.headers['x-cp'] = authService.getToken();
                config.headers['Access-Control-Allow-Origin'] = 'x-cp,Set-Cookie,Date';
                return config;
            },

            'requestError': function(rejection) {
                $rootScope.$broadcast('http:requestError');
                return $q.reject(rejection);
            },

            'response': function(response) {
                if(response.headers['x-cp']) {
                    authService.setToken(response.headers['x-cp'])
                }
                return response;
            },

            'responseError': function(rejection) {
                var $state = $injector.get('$state');
                var $ionicHistory = $injector.get('$ionicHistory');
                if (rejection.status == 401 || rejection.status == 403) {
                    authService.clearToken();
                    $ionicHistory.nextViewOptions({
                        disableBack: true
                    });
                    $state.go('cheping.user-login', { backState: $state.current.name });
                }

                if (rejection.status == 400) {

                }

                if(rejection.status >= 500){
                    $rootScope.$broadcast('http:responseError-500');
                }

                return $q.reject(rejection);
            }
        };
    })
    .factory('loadingInterceptor', function($rootScope) {
        return {
            request: function(config) {
                $rootScope.$broadcast('loading:show');
                return config;
            },
            response: function(response) {
                $rootScope.$broadcast('loading:hide');
                return response;
            }
        };
    });