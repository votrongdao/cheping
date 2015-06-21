angular.module('cheping.daiban.detail', [
    'cheping.services.user',
    'cheping.services.case',
    'cheping.daiban.detail-yanche',
    'cheping.daiban.detail-baojia',
    'cheping.daiban.detail-shenhe'
])
    .config(function($stateProvider) {
        $stateProvider
            .state('cheping.daiban-detail', {
                url: '/daiban/detail/{:caseId}/{:caseNo}',
                views: {
                    'daiban': {
                        controller: 'DaibanDetailCtrl as _case',
                        templateUrl: 'app/daiban/detail/daiban-detail.tpl.html'
                    }
                }
            })
    })
    .controller('DaibanDetailCtrl', function($scope, $state, $stateParams, $ionicPopup, $ionicHistory, UserService, CaseService) {
        var _case = this;
        _case.rejectButtonText = '取消';
        _case.confirmButtonText = '确认';

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

        _case.checkOperation = function() {
            return UserService.getUserInfo()
                .then(function(result) {
                    if (result.jobTitle === 40) {
                        if(_case.state === 20) {
                            _case.rejectButtonText = '审核不通过';
                            _case.confirmButtonText = '同意验车';
                        }else if (_case.state === 50) {
                            _case.rejectButtonText = '放弃报价';
                            _case.confirmButtonText = '报价';
                        }else if(_case.state === 70) {
                            _case.rejectButtonText = '放弃申请';
                            _case.confirmButtonText = '申请打款';
                        }else {
                            _case.rejectButtonText = '失败';
                            _case.confirmButtonText = '成功';
                        }

                    } else if (result.jobTitle === 10) {
                        if(_case.state === 30) {
                            _case.rejectButtonText = '验车失败';
                            _case.confirmButtonText = '验车成功';
                        }else if (_case.state === 60) {
                            _case.rejectButtonText = '洽谈失败';
                            _case.confirmButtonText = '洽谈成功';
                        }else if(_case.state === 90) {
                            _case.rejectButtonText = '入库失败';
                            _case.confirmButtonText = '入库';
                        }else {
                            _case.rejectButtonText = '失败';
                            _case.confirmButtonText = '成功';
                        }

                    } else if (result.jobTitle === 50) {
                        if(_case.state === 80) {
                            _case.rejectButtonText = '放弃收购';
                            _case.confirmButtonText = '打款';
                        }else {
                            _case.rejectButtonText = '失败';
                            _case.confirmButtonText = '成功';
                        }

                    } else {
                        UtilityService.showAlert('请先登录');
                        $state.go('cheping.user-login');
                    }

                    return result;
                });
        };

        _case.showRejectButton = function(){
            var state = [20, 30, 50, 60, 70, 80, 90];
            return state.indexOf(_case.state) !== -1;
        };

        _case.showConfirmButton = function(){
            var state = [20, 30, 50, 60, 70, 80];
            return state.indexOf(_case.state) !== -1;
        };

        _case.reject = function() {
            $scope.data = {};

            var popup = $ionicPopup.show({
                template: '<input type="text" ng-model="data.reason">',
                title: '请输入原因',
                scope: $scope,
                buttons: [
                    {text: '取消'},
                    {
                        text: '<b>确认</b>',
                        type: 'button-positive',
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
                if(res) {
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
            if(_case.state === 20) {
                $state.go('cheping.daiban-detail-yanche', {
                    caseId: $stateParams.caseId,
                    caseNo: $stateParams.caseNo
                });
            }else if (_case.state === 30) {
                $state.go('cheping.daiban-detail-yanche', {
                    caseId: $stateParams.caseId,
                    caseNo: $stateParams.caseNo
                });
            }else if (_case.state === 50) {
                $state.go('cheping.daiban-detail-yanche', {
                    caseId: $stateParams.caseId,
                    caseNo: $stateParams.caseNo
                });
            }else if (_case.state === 60) {
                $state.go('cheping.daiban-detail-yanche', {
                    caseId: $stateParams.caseId,
                    caseNo: $stateParams.caseNo
                });
            }else if (_case.state === 70) {
                $state.go('cheping.daiban-detail-yanche', {
                    caseId: $stateParams.caseId,
                    caseNo: $stateParams.caseNo
                });
            }else if (_case.state === 80) {
                $state.go('cheping.daiban-detail-yanche', {
                    caseId: $stateParams.caseId,
                    caseNo: $stateParams.caseNo
                });
            }else if(_case.state === 90) {
                $state.go('cheping.daiban-detail-yanche', {
                    caseId: $stateParams.caseId,
                    caseNo: $stateParams.caseNo
                });
            }else {
                $state.go('cheping.daiban-detail-yanche', {
                    caseId: $stateParams.caseId,
                    caseNo: $stateParams.caseNo
                });
            }
        };

        _case.getCase()
            .then(function(result) {
                _case.checkOperation();
            });
    });