angular.module('cheping.warning.detail', [
    'cheping.services.user',
    'cheping.services.case'
])
    .config(function($stateProvider) {
        $stateProvider
            .state('cheping.warning-detail', {
                url: '/warning/detail/{caseId}/{caseNo}',
                views: {
                    'warning': {
                        controller: 'WarningDetailCtrl as _case',
                        templateUrl: 'app/warning/detail/warning-detail.tpl.html'
                    }
                }
            })
    })
    .controller('WarningDetailCtrl', function($scope, $state, $stateParams, $ionicPopup, $ionicHistory, UserService, CaseService, UtilityService) {
        var _case = this;

        _case.getCase = function() {
            return CaseService.getCase($stateParams.caseId)
                .then(function(result) {
                    _case.caseNo = $stateParams.caseNo;
                    _case.abandon = result.abandon;
                    _case.abandonReason = result.abandonReason;
                    _case.bondsNote = result.bondsNote || '无';
                    _case.bondsState = result.bondsState;
                    _case.brandName = result.brandName;
                    _case.caseType = result.caseType;
                    _case.claimNote = result.claimNote || '无';
                    _case.claimState = result.claimState;
                    _case.conservationNote = result.conservationNote || '无';
                    _case.conservationState = result.conservationState;
                    _case.cooperationMethod = result.cooperationMethod;
                    _case.createTime = result.createTime;
                    _case.directorId = result.directorId;
                    _case.displayMileage = result.displayMileage;
                    _case.engineCode = result.engineCode;
                    _case.expectedPrice = result.expectedPrice || '未填写';
                    _case.factoryTime = result.factoryTime || '未填写';
                    _case.floorPrice = result.floorPrice;
                    _case.id = result.id;
                    _case.innerColor = result.innerColor;
                    _case.insuranceCode = result.insuranceCode;
                    _case.lastConservationTime = result.lastConservationTime;
                    _case.licenseCode = result.licenseCode;
                    _case.licenseLocation = result.licenseLocation || '未填写';
                    _case.licenseTime = result.licenseTime;
                    _case.managerId = result.managerId;
                    _case.maxMileage = result.maxMileage;
                    _case.minMileage = result.minMileage;
                    _case.modelId = result.modelId;
                    _case.modelName = result.modelName;
                    _case.modifiedContent = result.modifiedContent || '未填写';
                    _case.outerColor = result.outerColor;
                    _case.outletId = result.outletId;
                    _case.photo = result.photo;
                    _case.photoContents = result.photoContents;
                    _case.photos = result.photos;
                    _case.preferentialPrice = result.preferentialPrice;
                    _case.purchasePrice = result.purchasePrice;
                    _case.purchaserId = result.purchaserId;
                    _case.queryingId = result.queryingId;
                    _case.realMileage = result.realMileage;
                    _case.saleGrade = result.saleGrade;
                    _case.serialId = result.serialId;
                    _case.seriesName = result.seriesName;
                    _case.state = result.state;
                    _case.valuerId = result.valuerId;
                    _case.valuerName = result.valuerName;
                    _case.vehicleInfoId = result.vehicleInfoId;
                    _case.vehicleInspecId = result.vehicleInspecId;
                    _case.vehicleLocation = result.vehicleLocation;
                    _case.vinCode = result.vinCode;
                    _case.violationNote = result.violationNote || '无';
                    _case.violationState = result.violationState;
                    _case.webAveragePrice = result.webAveragePrice;
                    _case.webPrice = result.webPrice;
                    return result;
                });
        };

        _case.resetView = function () {
            _case.showPhotos();
            _case.showValueInfo();
            _case.showYancheInfo();
            _case.showChaxunInfo();
        };

        _case.showPhotos = function() {
            _case.showPhotosInView = _case.photoContents.length > 0;
        };

        _case.showValueInfo = function() {
            var state = [20, 25, 35, 50, 55, 65, 70, 75, 80, 85, 95];
            _case.showValueInfoInView = state.indexOf(_case.state) !== -1
                && _case.modelId > 0;
        };

        _case.showYancheInfo = function() {
            var state = [40, 50, 55, 60, 65, 70, 75, 80, 85, 90, 95, 100];
            _case.showYancheInfoInView = state.indexOf(_case.state) !== -1;
        };

        _case.showChaxunInfo = function() {
            var state = [50, 55, 60, 65, 70, 75, 80, 85, 90, 95, 100];
            _case.showChaxunInfoInView = state.indexOf(_case.state) !== -1;
        };

        _case.getCase()
            .then(function(result) {
                _case.resetView();
            });
    });