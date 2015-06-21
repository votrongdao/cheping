angular.module('cheping.case.list', [
    'cheping.services.user',
    'cheping.services.case',
    'cheping.case.detail'
])
    .config(function($stateProvider) {
        $stateProvider
            .state('cheping.case-list', {
                url: '/cases/list/{:carType}',
                views: {
                    'cases': {
                        controller: 'CaseListCtrl as cases',
                        templateUrl: 'app/case/list/case-list.tpl.html'
                    }
                }
            })
    })
    .controller('CaseListCtrl', function($scope, $state, $stateParams, $timeout, UserService, CaseService, UtilityService) {
        var cases = this;
        var nextPageIndex = 0;
        var user = UserService.getUserInfo();

        cases.items = [];
        cases.hasNextPage = false;

        cases.getCases = function() {
            CaseService.getCases(nextPageIndex, $stateParams.carType)
                .then(function(result) {
                    _.forEach(result.items, function(i) {
                        cases.items.push(i);
                    });

                    cases.hasNextPage = result.hasNextPage;
                    nextPageIndex = result.pageIndex + 1;
                })
        };

        cases.loadMore = function() {
            if(cases.hasNextPage) {
                cases.getCases();
            }
        };

        cases.getCases();

        cases.doRefresh = function() {
            nextPageIndex = 0;
            cases.items = [];
            cases.hasNextPage = false;
            cases.getCases();

            $timeout(function() {
                $scope.$broadcast('scroll.refreshComplete');
            }, 500);
        };
    });