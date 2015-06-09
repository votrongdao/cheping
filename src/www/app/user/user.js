angular.module('cheping.user', [
    'cheping.services.auth'
])
    .config(function($stateProvider) {
        $stateProvider
            .state('cheping.user', {
                url: '/user/login',
                views: {
                    'cheping@': {
                        controller: 'UserCtrl as userCtrl',
                        templateUrl: 'app/user/user-login.tpl.html'
                    }
                }
            })
    })
    .controller('UserCtrl', function($state, $ionicPopup, $timeout, ChepingAuthService) {
        var userCtrl = this;
        userCtrl.userName = '';
        userCtrl.password = '';

        userCtrl.loginButtonEnable = function(){
            return userCtrl.userName && userCtrl.password;
        };

        userCtrl.loginIn = function() {
            var message = '用户名或者密码不正确<br>如忘记密码，请联系管理员';
            if (ChepingAuthService.checkPassword(userCtrl.userName, userCtrl.password)) {
                $state.go('cheping.index.todos')
            }
            else{
                var alertPopup = $ionicPopup.alert({
                    title: '提示信息',
                    template: message,
                    cssClass: 'popup-alert'
                });

                $timeout(function() {
                    alertPopup.close();
                }, 2000);
            }
        }

    });
