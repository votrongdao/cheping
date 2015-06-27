angular.module('cheping.user.login', [
    'cheping.services.user',
    'cheping.case'
])
    .config(function ($stateProvider) {
        $stateProvider
            .state('cheping.user-login', {
                url: '/user/login',
                views: {
                    '@':{
                        controller: 'UserLoginCtrl as user',
                        templateUrl: 'app/user/login/user-login.tpl.html'
                    }
                }
            })
    })
    .controller('UserLoginCtrl', function($state, $ionicHistory, UserService, UtilityService) {
        var user = this;

        user.model = {};
        user.viewModel = {};

        user.login = function() {
            if(/^(13|14|15|17|18)\d{9}$/.test(user.viewModel.cellphone) &&
                /^[a-zA-Z\d~!@#$%^&*_]{6,18}$/.test(user.viewModel.password)) {
                UserService.login(user.viewModel.cellphone, user.viewModel.password)
                    .then(function (result) {
                        $ionicHistory.nextViewOptions({
                            disableBack: true
                        });
                        $state.go('cheping.case', {}, { reload: true });
                    }, function(reason) {
                        //UtilityService.showAlert(reason.data.message);
                    });

            }
        };

        user.loginButtonEnable = function() {
            return user.viewModel.cellphone && user.viewModel.password;
        };
    });