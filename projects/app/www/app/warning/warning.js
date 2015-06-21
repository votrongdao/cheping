angular.module('cheping.warning', [
    'cheping.services.user',
    'cheping.services.case'
])
    .config(function($stateProvider) {
        $stateProvider
            .state('cheping.warning', {
                url: '/warning',
                views: {
                    'warning': {
                        controller: 'WarningCtrl as cases',
                        templateUrl: 'app/warning/index.tpl.html'
                    }
                }
            })
    })
    .controller('WarningCtrl', function($scope, $state, $timeout, UserService, CaseService, UtilityService) {
        var cases = this;
        var user = UserService.getUserInfo();

        cases.items = [];

        cases.getTodos = function() {
            CaseService.getTodos()
                .then(function(result) {
                    cases.items = result;
                })
        };

        cases.getTodos();

        cases.doRefresh = function() {
            cases.getTodos();

            $timeout(function() {
                $scope.$broadcast('scroll.refreshComplete');
            }, 500);
        };
    });