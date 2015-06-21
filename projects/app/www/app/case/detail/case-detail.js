angular.module('cheping.case.detail', [
    'cheping.services.user',
    'cheping.services.case'
])
    .config(function($stateProvider) {
        $stateProvider
            .state('cheping.case-detail', {
                url: '/cases/detail/{:caseId}/{:caseNo}',
                views: {
                    'cases': {
                        controller: 'CaseDetailCtrl as _case',
                        templateUrl: 'app/case/detail/case-detail.tpl.html'
                    }
                }
            })
    })
    .controller('CaseDetailCtrl', function($state, $stateParams, CaseService) {
        var _case = this;

        _case.getCase = function() {
            CaseService.getCase($stateParams.caseId)
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
                })
        };

        _case.getCase();
    });