angular.module('cheping.daiban.detail-shenqingdakuan', [
    'cheping.services.user',
    'cheping.services.case'
])
    .config(function($stateProvider) {
        $stateProvider
            .state('cheping.daiban-detail-shenqingdakuan', {
                url: '/daiban/detail/shenqingdakuan/{:caseId}/{:caseNo}',
                views: {
                    'daiban': {
                        controller: 'DaibanShenqingdakuanCtrl as _case',
                        templateUrl: 'app/daiban/detail/daiban-shenqingdakuan.tpl.html'
                    }
                }
            })
    })
    .controller('DaibanShenqingdakuanCtrl', function($scope, $state, $stateParams, $ionicPopup, $ionicHistory, UserService, CaseService) {
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
                    _case.purchasePrice = result.purchasePrice;
                    _case.seriesName = result.seriesName;
                    _case.state = result.state;
                    _case.vehicleLocation = result.vehicleLocation;
                    return result;
                });
        };

        _case.buttonEnable = function() {
            return true;
        };

        _case.confirm = function() {
            CaseService.applyPayment($stateParams.caseId).then(function(result) {
                $ionicHistory.nextViewOptions({
                    disableBack: true
                });
                $state.go('cheping.daiban');
            });
        };

        _case.getCase();
    });