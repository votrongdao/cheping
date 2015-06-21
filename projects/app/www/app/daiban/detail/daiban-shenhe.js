angular.module('cheping.daiban.detail-yanche', [
    'cheping.services.user',
    'cheping.services.case'
])
    .config(function($stateProvider) {
        $stateProvider
            .state('cheping.daiban-detail-yanche', {
                url: '/daiban/detail/yanche/{:caseId}/{:caseNo}',
                views: {
                    'daiban': {
                        controller: 'DaibanYancheCtrl as _case',
                        templateUrl: 'app/daiban/detail/daiban-yanche.tpl.html'
                    }
                }
            })
    })
    .controller('DaibanYancheCtrl', function($scope, $state, $stateParams, $ionicPopup, $ionicHistory, UserService, CaseService) {
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
            return _case.VIN && _case.engineCode && _case.insuranceCode && _case.license;
        };

        _case.confirm = function() {
            CaseService.addYancheInfo({
                caseId: $stateParams.caseId,
                engineCode: _case.engineCode,
                insuranceCode: _case.insuranceCode,
                licenseCode: _case.license,
                vinCode: _case.VIN
            }).then(function(result) {
                $ionicHistory.nextViewOptions({
                    disableBack: true
                });
                $state.go('cheping.daiban');
            });
        };

        _case.getCase();
    });