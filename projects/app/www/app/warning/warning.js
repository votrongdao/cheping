angular.module('cheping.warning', [
    'cheping.services.user',
    'cheping.services.case',
    'cheping.warning.detail'
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

        cases.getWarnings = function() {
            CaseService.getWarnings()
                .then(function(result) {
                    cases.items = result;
                })
        };

        cases.getWarnings();

        cases.doRefresh = function() {
            cases.getWarnings();

            $timeout(function() {
                $scope.$broadcast('scroll.refreshComplete');
            }, 500);
        };

        cases.comfirmWarning = function(caseId) {
            CaseService.rejectionConfirm(caseId)
                .then(function(result) {
                    cases.getWarnings();
                });
        };
    });