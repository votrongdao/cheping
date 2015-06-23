angular.module('cheping.daiban.detail-yanche', [
    'cheping.services.user',
    'cheping.services.case'
])
    .config(function($stateProvider) {
        $stateProvider
            .state('cheping.daiban-detail-yanche', {
                url: '/daiban/detail/yanche/{caseId}/{caseNo}',
                views: {
                    'daiban': {
                        controller: 'DaibanYancheCtrl as _case',
                        templateUrl: 'app/daiban/detail/daiban-yanche.tpl.html'
                    }
                }
            })
    })
    .controller('DaibanYancheCtrl', function($scope, $state, $stateParams, $ionicPopup, $ionicHistory, $cordovaCamera, UserService, CaseService, CaseCreateService, UtilityService) {
        var _case = this;

        _case.yanchePhotos = [];

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
                    _case.photoContents = result.photoContents;
                    _case.yanchePhotos = [];
                    return result;
                });
        };

        _case.buttonEnable = function() {
            return _case.VIN && _case.engineCode && _case.insuranceCode && _case.license;
        };

        _case.confirm = function() {
            var photos = [];

            _.forEach(_case.yanchePhotos, function(p) {
                photos.push(p.id);
            });

            CaseService.addYancheInfo({
                caseId: $stateParams.caseId,
                engineCode: _case.engineCode,
                insuranceCode: _case.insuranceCode,
                licenseCode: _case.license,
                vinCode: _case.VIN,
                photoIds: photos
            }).then(function(result) {
                $ionicHistory.nextViewOptions({
                    disableBack: true
                });
                $state.go('cheping.daiban');
            });
        };

        _case.canAddPhoto = function() {
            return _case.yanchePhotos.length <= 10;
        };

        _case.takePicture = function() {
            var options = {
                quality: 50,
                destinationType: Camera.DestinationType.DATA_URL,
                sourceType: Camera.PictureSourceType.CAMERA,
                allowEdit: false,
                encodingType: Camera.EncodingType.JPEG,
                targetWidth: 300,
                targetHeight: 400,
                saveToPhotoAlbum: false
            };

            $cordovaCamera.getPicture(options).then(function(imageData) {
                CaseCreateService.addYanchePhoto('data:image/jpeg;base64,' + imageData)
                    .then(function(result) {
                        _case.yanchePhotos.push(result);
                    });
            }, function(err) {
                UtilityService.showAlert('未能添加图片，请重试')
            });

        };

        _case.removePhoto = function(photoId) {
            _.remove(_case.yanchePhotos, function(p) {
                return p.id === photoId;
            });
        };

        _case.getCase();
    });