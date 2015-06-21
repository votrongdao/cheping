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
    .controller('UserCtrl', function($state, $ionicHistory, UserService, AuthService, UtilityService) {
        var user = this;

        UserService.getUserInfo()
            .then(function(currentUser) {
                user.cellphone = currentUser.cellphone;
                user.outletId = currentUser.outletId;
                user.userName = currentUser.userName;
                user.userCode = currentUser.userCode;
                user.jobTitle = currentUser.jobTitle;
            });

        user.loginOut = function() {
            AuthService.clearToken();
            $ionicHistory.nextViewOptions({
                disableBack: true
            });
            $state.go('cheping.user-login');
        };
    });