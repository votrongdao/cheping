angular.module('cheping.daiban.detail', [
    'cheping.services.user',
    'cheping.services.case',
    'cheping.daiban.detail-baojia',
    'cheping.daiban.detail-caigou',
    'cheping.daiban.detail-dakuanshenhe',
    'cheping.daiban.detail-qiatan',
    'cheping.daiban.detail-shenhe',
    'cheping.daiban.detail-shenqingdakuan',
    'cheping.daiban.detail-yanche'
])
    .config(function($stateProvider) {
        $stateProvider
            .state('cheping.daiban-detail', {
                url: '/daiban/detail/{caseId}/{caseNo}',
                views: {
                    'daiban': {
                        controller: 'DaibanDetailCtrl as _case',
                        templateUrl: 'app/daiban/detail/daiban-detail.tpl.html'
                    }
                }
            })
    })
    .controller('DaibanDetailCtrl', function($scope, $state, $stateParams, $ionicPopup, $ionicHistory, UserService, CaseService, UtilityService) {
        var _case = this;
        _case.rejectButtonText = '取消';
        _case.confirmButtonText = '确认';

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

        _case.checkOperation = function() {
            return UserService.getUserInfo()
                .then(function(result) {
                    if (result.jobTitle === 40) {
                        if (_case.state === 20) {
                            _case.rejectButtonText = '审核不通过';
                            _case.confirmButtonText = '同意验车';
                        } else if (_case.state === 50) {
                            _case.rejectButtonText = '放弃报价';
                            _case.confirmButtonText = '报价';
                        } else if (_case.state === 70) {
                            _case.rejectButtonText = '放弃申请';
                            _case.confirmButtonText = '申请打款';
                        } else {
                            _case.rejectButtonText = '失败';
                            _case.confirmButtonText = '成功';
                        }

                    } else if (result.jobTitle === 10) {
                        if (_case.state === 30) {
                            _case.rejectButtonText = '验车失败';
                            _case.confirmButtonText = '验车成功';
                        } else if (_case.state === 60) {
                            _case.rejectButtonText = '洽谈失败';
                            _case.confirmButtonText = '洽谈成功';
                        } else if (_case.state === 90) {
                            _case.rejectButtonText = '入库失败';
                            _case.confirmButtonText = '入库';
                        } else {
                            _case.rejectButtonText = '失败';
                            _case.confirmButtonText = '成功';
                        }

                    } else if (result.jobTitle === 50) {
                        if (_case.state === 80) {
                            _case.rejectButtonText = '放弃收购';
                            _case.confirmButtonText = '同意打款';
                        } else {
                            _case.rejectButtonText = '失败';
                            _case.confirmButtonText = '成功';
                        }

                    } else {
                        UtilityService.showAlert('请先登录');
                        $timeout(function() {
                            $state.go('cheping.user-login');
                        }, 1000);
                    }

                    return result;
                });
        };

        _case.resetView = function () {
            _case.enableTranscations();
            _case.showRejectButton();
            _case.showConfirmButton();
            _case.showPhotos();
            _case.showValueInfo();
            _case.showYancheInfo();
            _case.showChaxunInfo();
        };

        _case.enableTranscations = function() {
            var state = [20, 50, 70, 80];
            _case.enableTranscationsInView = state.indexOf(_case.state) !== -1 && _case.modelId > 0;
        };

        _case.goTranscations = function() {
            $state.go('cheping.daiban-transcation-record', {
                caseId: _case.id,
                brand: _case.brandName,
                series: _case.seriesName,
                model: _case.modelName
            });
        };

        _case.showRejectButton = function() {
            var state = [20, 30, 50, 60, 70, 80];
            _case.showRejectButtonInView = state.indexOf(_case.state) !== -1;
        };

        _case.showConfirmButton = function() {
            var state = [20, 30, 50, 60, 70, 80, 90];
            _case.showConfirmButtonInView = state.indexOf(_case.state) !== -1;
        };

        _case.showPhotos = function() {
            _case.showPhotosInView = _case.photoContents.length > 0;
        };

        _case.showValueInfo = function() {
            var state = [20, 50, 70, 80];
            _case.showValueInfoInView = state.indexOf(_case.state) !== -1
            && _case.modelId > 0;
        };

        _case.showYancheInfo = function() {
            var state = [40, 50, 60, 70, 80, 90, 100];
            _case.showYancheInfoInView = state.indexOf(_case.state) !== -1;
        };

        _case.showChaxunInfo = function() {
            var state = [50, 60, 70, 80, 90, 100];
            _case.showChaxunInfoInView = state.indexOf(_case.state) !== -1;
        };

        _case.reject = function() {
            $scope.data = {};

            var popup = $ionicPopup.show({
                template: '<input type="text" ng-model="data.reason">',
                title: '请输入原因',
                scope: $scope,
                buttons: [
                    {
                        text: '取消',
                        type: 'button-cp-green'
                    },
                    {
                        text: '<b>确认</b>',
                        type: 'button-cp-dark',
                        onTap: function(e) {
                            if (!$scope.data.reason) {
                                e.preventDefault();
                            } else {
                                return $scope.data.reason;
                            }
                        }
                    }
                ]
            });

            popup.then(function(res) {
                if (res) {
                    CaseService.reject($stateParams.caseId, res)
                        .then(function(result) {
                            $ionicHistory.nextViewOptions({
                                disableBack: true
                            });
                            $state.go('cheping.daiban');
                        });
                }
            });


        };

        _case.confirm = function() {
            if (_case.state === 20) {
                $state.go('cheping.daiban-detail-shenhe', {
                    caseId: $stateParams.caseId,
                    caseNo: $stateParams.caseNo
                });
            } else if (_case.state === 30) {
                $state.go('cheping.daiban-detail-yanche', {
                    caseId: $stateParams.caseId,
                    caseNo: $stateParams.caseNo
                });
            } else if (_case.state === 50) {
                $state.go('cheping.daiban-detail-baojia', {
                    caseId: $stateParams.caseId,
                    caseNo: $stateParams.caseNo
                });
            } else if (_case.state === 60) {
                $state.go('cheping.daiban-detail-qiatan', {
                    caseId: $stateParams.caseId,
                    caseNo: $stateParams.caseNo
                });
            } else if (_case.state === 70) {
                $state.go('cheping.daiban-detail-shenqingdakuan', {
                    caseId: $stateParams.caseId,
                    caseNo: $stateParams.caseNo
                });
            } else if (_case.state === 80) {
                $state.go('cheping.daiban-detail-dakuanshenhe', {
                    caseId: $stateParams.caseId,
                    caseNo: $stateParams.caseNo
                });
            } else if (_case.state === 90) {
                $state.go('cheping.daiban-detail-caigou', {
                    caseId: $stateParams.caseId,
                    caseNo: $stateParams.caseNo
                });
            } else {
                UtilityService.showAlert('请先登录');
                $timeout(function() {
                    $state.go('cheping.user-login');
                }, 1000);

            }
        };

        _case.getCase()
            .then(function(result) {
                _case.checkOperation();
            })
            .then(function(result) {
                _case.resetView();
            });
    });