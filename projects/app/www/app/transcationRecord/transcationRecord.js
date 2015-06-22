angular.module('cheping.transcations', [
    'cheping.services.user',
    'cheping.services.case'
])
    .config(function($stateProvider) {
        $stateProvider
            .state('cheping.daiban-transcation-record', {
                url: '/daiban/transcation-record/{caseId}/{brand}/{series}/{model}',
                views: {
                    'daiban': {
                        controller: 'TranscationRecordsCtrl as _case',
                        templateUrl: 'app/transcationRecord/index.tpl.html'
                    }
                }
            })
    })
    .config(function($stateProvider) {
        $stateProvider
            .state('cheping.case-transcation-record', {
                url: '/case/transcation-record/{caseId}/{brand}/{series}/{model}',
                views: {
                    'case': {
                        controller: 'TranscationRecordsCtrl as _case',
                        templateUrl: 'app/transcationRecord/index.tpl.html'
                    }
                }
            })
    })
    .controller('TranscationRecordsCtrl', function($scope, $state, $stateParams, $timeout, UserService, CaseService, UtilityService) {
        var _case = this;
        UserService.getUserInfo();

        _case.brand = $stateParams.brand;
        _case.series = $stateParams.series;
        _case.model = $stateParams.model;

        _case.items = [];

        cases.getRecords = function() {
            CaseService.getTranscations()
                .then(function(result) {
                    cases.items = result;
                })
        };

        cases.getRecords();

        cases.doRefresh = function() {
            cases.getRecords();

            $timeout(function() {
                $scope.$broadcast('scroll.refreshComplete');
            }, 500);
        };
    });