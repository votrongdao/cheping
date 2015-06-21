angular.module('cheping.daiban.detail-baojia', [
    'cheping.services.user',
    'cheping.services.case'
])
    .config(function($stateProvider) {
        $stateProvider
            .state('cheping.daiban-detail-baojia', {
                url: '/daiban/detail/baojia/{caseId}/{caseNo}',
                views: {
                    'daiban': {
                        controller: 'DaibanBaojiaCtrl as _case',
                        templateUrl: 'app/daiban/detail/daiban-baojia.tpl.html'
                    }
                }
            })
    })
    .controller('DaibanBaojiaCtrl', function($scope, $state, $stateParams, $ionicPopup, $ionicHistory, UserService, CaseService) {
        var _case = this;

        _case.getCase = function() {
            return CaseService.getCase($stateParams.caseId)
                .then(function(result) {
                    _case.caseNo = $stateParams.caseNo;
                    _case.brandName = result.brandName;
                    _case.cooperationMethod = result.cooperationMethod;
                    _case.displayMileage = result.displayMileage;
                    _case.expectedPrice = result.expectedPrice;
                    _case.factoryTime = result.factoryTime;
                    _case.id = result.id;
                    _case.innerColor = result.innerColor;
                    _case.licenseLocation = result.licenseLocation;
                    _case.licenseTime = result.licenseTime;
                    _case.modelId = result.modelId;
                    _case.modelName = result.modelName;
                    _case.modifiedContent = result.modifiedContent;
                    _case.outerColor = result.outerColor;
                    _case.seriesName = result.seriesName;
                    _case.state = result.state;
                    _case.vehicleLocation = result.vehicleLocation;
                    return result;
                });
        };

        _case.buttonEnable = function() {
            return _case.price;
        };

        _case.confirm = function() {
            CaseService.reviewCase($stateParams.caseId, _case.price).then(function(result) {
                $ionicHistory.nextViewOptions({
                    disableBack: true
                });
                $state.go('cheping.daiban');
            });
        };

        _case.getCase();
    });