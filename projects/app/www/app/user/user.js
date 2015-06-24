angular.module('cheping.user', [
])
    .config(function ($stateProvider) {
        $stateProvider
            .state('cheping.user', {
                url: '/user',
                views: {
                    'user':{
                        controller: 'UserCtrl as user',
                        templateUrl: 'app/user/index.tpl.html'
                    }
                }
            })
    })
    .controller('UserCtrl', function($state, $ionicHistory, UserService, AuthService, UtilityService, CacheService) {
        var user = this;

        UserService.getUserInfo()
            .then(function(currentUser) {
                user.cellphone = currentUser.cellphone.toString();
                user.outletId = currentUser.outletId;
                user.userName = currentUser.userName;
                user.userCode = currentUser.userCode;
                user.jobTitle = currentUser.jobTitle;
                user.outletName = currentUser.outletName;
            });

        user.loginOut = function() {
            AuthService.clearToken();

            CacheService.get('caseCache').removeAll();
            CacheService.get('userCache').removeAll();

            $ionicHistory.nextViewOptions({
                disableBack: true
            });
            $state.go('cheping.user-login');
        };
    });