angular.module('cheping.transcations', [
    'cheping.services.user',
    'cheping.services.case'
])
    .config(function($stateProvider) {
        $stateProvider
            .state('cheping.daiban-transcation-record', {
                url: '/daiban/transcation-record/{caseId}/{brand}/{series}/{model}/{min}/{max}',
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
                url: '/case/transcation-record/{caseId}/{brand}/{series}/{model}/{min}/{max}',
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
        _case.brand = $stateParams.brand;
        _case.series = $stateParams.series;
        _case.model = $stateParams.model;

        var min = parseInt($stateParams.min);
        var max = parseInt($stateParams.max);

        _case.min = min;
        _case.max = max;

        _case.floorPrice = 0;
        _case.webAveragePrice = 0;
        _case.webPrice = 0;
        _case.count = 0;

        _case.items = [];

        _case.chongzhi = function() {
            _case.min = min;
            _case.max = max;
            _case.getRecords();
        };

        _case.chaxun = function() {
            _case.getRecords();
        };

        _case.getRecords = function() {

            CaseService.getTranscations($stateParams.caseId, _case.min, _case.max)
                .then(function(result) {
                    _case.items = result.records;
                    _case.floorPrice = result.floorPrice;
                    _case.webAveragePrice = result.webAveragePrice;
                    _case.webPrice = result.webPrice;
                    _case.count = result.records.length;
                })
        };

        _case.getRecords();

        _case.doRefresh = function() {
            _case.min = min;
            _case.max = max;
            _case.getRecords();

            $timeout(function() {
                $scope.$broadcast('scroll.refreshComplete');
            }, 500);
        };

        $scope.$on('$ionicView.enter', function() {
            _case.min = min;
            _case.max = max;
            _case.getRecords();
        });
    });