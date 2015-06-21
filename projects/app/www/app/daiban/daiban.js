angular.module('cheping.daiban', [
    'cheping.services.user',
    'cheping.services.case',
    'cheping.daiban.detail'
])
    .config(function($stateProvider) {
        $stateProvider
            .state('cheping.daiban', {
                url: '/daiban',
                views: {
                    'daiban': {
                        controller: 'DaibanCtrl as cases',
                        templateUrl: 'app/daiban/index.tpl.html'
                    }
                }
            })
    })
    .controller('DaibanCtrl', function($scope, $state, $timeout, UserService, CaseService, UtilityService) {
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