angular.module('cheping.case.list', [
    'cheping.services.user'
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
    .controller('CaseListCtrl', function($state, $stateParams, UserService, CaseService, UtilityService) {
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

                    nextPageIndex = result.pageIndex + 1;
                })
        };

        cases.loadMore = function() {
            if(cases.hasNextPage) {
                cases.getCases();
            }
        };

        cases.getCases();
    });