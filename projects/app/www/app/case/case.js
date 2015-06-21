angular.module('cheping.user.login', [
    'cheping.services.user'
])
    .config(function ($stateProvider) {
        $stateProvider
            .state('cheping.case', {
                url: '/case',
                views: {
                    'cases':{
                        controller: 'CaseCtrl as ctrl',
                        templateUrl: 'app/case/index.tpl.html'
                    }
                }
            })
    })
    .controller('CaseCtrl', function($state, UserService, UtilityService) {
        var ctrl = this;

        ctrl.model = {};
        ctrl.viewModel = {};

        var user = UserService.getUserInfo();

        user.login = function() {
            if(/^(13|14|15|17|18)\d{9}$/.test(user.viewModel.cellphone) &&
                /^[a-zA-Z\d~!@#$%^&*_]{6,18}$/.test(user.viewModel.password)) {
                UserService.login(user.viewModel.cellphone, user.viewModel.password)
                    .then(function (result) {
                        $ionicHistory.nextViewOptions({
                            disableBack: true
                        });
                        $state.go('', {}, { reload: true });
                    }, function(reason) {
                        UtilityService.showAlert(reason.data.message);
                    });

            }
        };

        user.loginButtonEnable = function() {
            return user.viewModel.cellphone && user.viewModel.password;
        };
    });