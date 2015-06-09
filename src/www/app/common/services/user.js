angular.module('cheping.services.auth', [
    'cheping.services.cache'
])
    .service('ChepingAuthService', function($state, ChepingCacheService) {
        var service = this;
        var users = [
            {
                userName: 15901230123,
                password: "19731234",
                cityNo: "001",
                outletNo: "012",
                employeeNo: "172"
            }];

        var cacheStorage = ChepingCacheService.get('storage');

        service.checkPassword = function(userName, password) {
            var user = _.find(users, function(user) {
                return user.userName === userName && user.password === password;
            });

            cacheStorage.put('user', user);

            return user !== undefined;
        };

        service.getUser = function() {
            var user = cacheStorage.get('user');
            if (user === undefined) {
                $state.go('cheping.user');
            }

            return user;
        }
    });