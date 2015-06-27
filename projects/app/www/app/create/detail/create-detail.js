angular.module('cheping.new.detail', [
    'cheping.services.caseCreate',
    'ngCordova'
])
    .config(function($stateProvider) {
        $stateProvider
            .state('cheping.new-detail', {
                url: '/new/detail/{carType}',
                views: {
                    'new': {
                        controller: 'NewCtrl as _case',
                        templateUrl: 'app/create/detail/create-detail.tpl.html'
                    }
                }
            })
            .state('cheping.new-brand', {
                url: '/new/brand',
                views: {
                    'new': {
                        controller: 'NewBrandCtrl as ctrl',
                        templateUrl: 'app/create/detail/create-detail-brand.tpl.html'
                    }
                }
            })
            .state('cheping.new-series', {
                url: '/new/series',
                views: {
                    'new': {
                        controller: 'NewSeriesCtrl as ctrl',
                        templateUrl: 'app/create/detail/create-detail-series.tpl.html'
                    }
                }
            })
            .state('cheping.new-model', {
                url: '/new/models',
                views: {
                    'new': {
                        controller: 'NewModelsCtrl as ctrl',
                        templateUrl: 'app/create/detail/create-detail-models.tpl.html'
                    }
                }
            })
            .state('cheping.new-outer-color', {
                url: '/new/outer-color',
                views: {
                    'new': {
                        controller: 'NewOuterColorCtrl as ctrl',
                        templateUrl: 'app/create/detail/create-detail-outer-color.tpl.html'
                    }
                }
            })
            .state('cheping.new-inner-color', {
                url: '/new/inner-color',
                views: {
                    'new': {
                        controller: 'NewInnerColorCtrl as ctrl',
                        templateUrl: 'app/create/detail/create-detail-inner-color.tpl.html'
                    }
                }
            })
            .state('cheping.new-cooperation-method', {
                url: '/new/cooperation-method',
                views: {
                    'new': {
                        controller: 'NewCooperationMethodCtrl as ctrl',
                        templateUrl: 'app/create/detail/create-detail-cooperation-method.tpl.html'
                    }
                }
            })
            .state('cheping.new-license-time', {
                url: '/new/license-time',
                views: {
                    'new': {
                        controller: 'NewLicenseTimeCtrl as ctrl',
                        templateUrl: 'app/create/detail/create-detail-license-time.tpl.html'
                    }
                }
            })
            .state('cheping.new-factory-time', {
                url: '/new/factory-time',
                views: {
                    'new': {
                        controller: 'NewFactoryTimeCtrl as ctrl',
                        templateUrl: 'app/create/detail/create-detail-factory-time.tpl.html'
                    }
                }
            })
            .state('cheping.new-vehicle-location', {
                url: '/new/vehicle-location',
                views: {
                    'new': {
                        controller: 'NewVehicleLocationCtrl as ctrl',
                        templateUrl: 'app/create/detail/create-detail-vehicle-location.tpl.html'
                    }
                }
            })
            .state('cheping.new-license-location', {
                url: '/new/license-location',
                views: {
                    'new': {
                        controller: 'NewLicenseLocationCtrl as ctrl',
                        templateUrl: 'app/create/detail/create-detail-license-location.tpl.html'
                    }
                }
            })
            .state('cheping.new-display-mileage', {
                url: '/new/display-mileage',
                views: {
                    'new': {
                        controller: 'NewDisplayMileageCtrl as ctrl',
                        templateUrl: 'app/create/detail/create-detail-display-mileage.tpl.html'
                    }
                }
            })
            .state('cheping.new-expected-price', {
                url: '/new/expected-price',
                views: {
                    'new': {
                        controller: 'NewExpectedPriceCtrl as ctrl',
                        templateUrl: 'app/create/detail/create-detail-expected-price.tpl.html'
                    }
                }
            })
            .state('cheping.new-modified-content', {
                url: '/new/modified-content',
                views: {
                    'new': {
                        controller: 'NewModifiedContentCtrl as ctrl',
                        templateUrl: 'app/create/detail/create-detail-modified-content.tpl.html'
                    }
                }
            });
    })
    .controller('NewCtrl', function($scope, $state, $stateParams, $timeout, $cordovaCamera, CaseCreateService, UtilityService) {
        var _case = this;

        _case.viewModel = {};

        var newCase = CaseCreateService.getNewCase();
        if (newCase.caseType !== $stateParams.carType) {
            newCase = CaseCreateService.resetNewCase($stateParams.carType);
        }

        _case.photos = newCase.photos;

        _case.resetViewModel = function() {
            var view = _case.viewModel;

            view.caseType = newCase.caseType || '车辆类型';
            view.brandName = newCase.brandName || '选择品牌';
            view.seriesName = newCase.seriesName || '选择车系';
            view.modelName = newCase.modelName || '选择车型';
            view.outerColor = newCase.outerColor || '选择车辆外部颜色';
            view.innerColor = newCase.innerColor || '选择车辆内饰颜色';
            view.licenseTime = newCase.licenseTime || '选择车辆上牌时间';
            view.vehicleLocation = newCase.vehicleLocation || '选择车辆所在地区';
            view.displayMileage = newCase.displayMileage || '输入里程数';
            view.cooperationMethod = newCase.cooperationMethod || '选择合作方式';
            view.factoryTime = newCase.factoryTime || '选择车辆出厂时间';
            view.licenseLocation = newCase.licenseLocation || '选择车辆牌照所在地';
            view.expectedPrice = newCase.expectedPrice || '车主心理价位';
            view.modifiedContent = newCase.modifiedContent || '改装内容';
        };

        _case.buttonEnable = function() {
            return newCase.caseType && newCase.brandName && newCase.seriesName && newCase.modelName &&
                newCase.outerColor && newCase.innerColor && newCase.licenseTime && newCase.vehicleLocation
                && newCase.displayMileage && newCase.cooperationMethod;
        };

        _case.createCase = function() {
            CaseCreateService.createCase()
                .then(function(result) {
                    UtilityService.showAlert('创建成功');
                    CaseCreateService.resetNewCase(10);
                    newCase = CaseCreateService.getNewCase();
                    _case.resetViewModel();
                    $timeout(function() {
                        $state.go('cheping.new');
                    }, 2000);
                });
        };

        _case.canAddPhoto = function() {
            return newCase.photos.length <= 10;
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
                CaseCreateService.addPhoto('data:image/jpeg;base64,' + imageData)
                    .then(function(result) {
                        _case.photos = newCase.photos;
                    });
            }, function(err) {
                UtilityService.showAlert('未能添加图片，请重试')
            });

        };

        _case.removePhoto = function(photoId) {
            _.remove(newCase.photos, function(p) {
                return p.id === photoId;
            });

            _case.photos = newCase.photos;
        };

        $scope.$on('$stateChangeSuccess', function(event, toState, toParams, fromState, fromParams) {
            if (toState.name === 'cheping.new-detail') {
                _case.resetViewModel();
            }

        });

    })
    .controller('NewBrandCtrl', function($scope, $state, $stateParams, $timeout, CaseCreateService) {
        var ctrl = this;
        var newCase = CaseCreateService.getNewCase();

        ctrl.items = [];
        ctrl.selected = newCase.brandName;

        ctrl.loadItems = function() {
            CaseCreateService.getBrands()
                .then(function(result) {
                    ctrl.items = result;
                });
        };

        ctrl.select = function(item) {
            ctrl.selected = item;
        };

        ctrl.selectConfirm = function() {
            if (ctrl.selected) {
                newCase.brandName = ctrl.selected;
                $state.go('cheping.new-detail', {carType: newCase.caseType});
            }
        };

        ctrl.buttonEnable = function() {
            return ctrl.selected;
        };

        ctrl.doRefresh = function() {
            ctrl.loadItems();

            $timeout(function() {
                $scope.$broadcast('scroll.refreshComplete');
            }, 500);
        };

        ctrl.loadItems();

    })
    .controller('NewSeriesCtrl', function($scope, $state, $stateParams, $timeout, CaseCreateService) {
        var ctrl = this;
        var newCase = CaseCreateService.getNewCase();

        ctrl.items = [];
        ctrl.selected = newCase.seriesName;

        ctrl.loadItems = function() {
            if (newCase.brandName) {
                CaseCreateService.getSeries(newCase.brandName)
                    .then(function(result) {
                        ctrl.items = result;
                    });
            }
        };

        ctrl.selectConfirm = function() {
            if (ctrl.selected) {
                newCase.seriesName = ctrl.selected;
                $state.go('cheping.new-detail', {carType: newCase.caseType});
            }
        };

        ctrl.buttonEnable = function() {
            return ctrl.selected;
        };

        ctrl.doRefresh = function() {
            ctrl.loadItems();

            $timeout(function() {
                $scope.$broadcast('scroll.refreshComplete');
            }, 500);
        };

        ctrl.loadItems();

    })
    .controller('NewModelsCtrl', function($scope, $state, $stateParams, $timeout, CaseCreateService) {
        var ctrl = this;
        var newCase = CaseCreateService.getNewCase();

        ctrl.items = [];
        ctrl.selected = newCase.modelName;

        ctrl.loadItems = function() {
            if (newCase.brandName && newCase.seriesName) {
                CaseCreateService.getModelings(newCase.brandName, newCase.seriesName)
                    .then(function(result) {
                        ctrl.items = result;
                    });
            }
        };

        ctrl.selectConfirm = function() {
            if (ctrl.selected) {
                newCase.modelName = ctrl.selected;
                $state.go('cheping.new-detail', {carType: newCase.caseType});
            }
        };

        ctrl.buttonEnable = function() {
            return ctrl.selected;
        };

        ctrl.doRefresh = function() {
            ctrl.loadItems();

            $timeout(function() {
                $scope.$broadcast('scroll.refreshComplete');
            }, 500);
        };

        ctrl.loadItems();

    })
    .controller('NewOuterColorCtrl', function($scope, $state, $stateParams, $timeout, CaseCreateService) {
        var ctrl = this;
        var newCase = CaseCreateService.getNewCase();

        ctrl.items = CaseCreateService.getColors();
        ctrl.selected = newCase.outerColorName;

        ctrl.select = function(item) {
            ctrl.selected = item;
        };

        ctrl.selectConfirm = function() {
            if (ctrl.selected && ctrl.selected !== newCase.outerColor) {
                newCase.outerColor = 0;
                newCase.outerColorName = ctrl.selected;
                $state.go('cheping.new-detail', {carType: newCase.caseType});
            }
        };

        ctrl.buttonEnable = function() {
            return ctrl.selected;
        };

    })
    .controller('NewInnerColorCtrl', function($scope, $state, $stateParams, $timeout, CaseCreateService) {
        var ctrl = this;
        var newCase = CaseCreateService.getNewCase();

        ctrl.items = CaseCreateService.getColors();
        ctrl.selected = newCase.outerColorName;

        ctrl.select = function(item) {
            ctrl.selected = item;
        };

        ctrl.selectConfirm = function() {
            if (ctrl.selected && ctrl.selected !== newCase.outerColor) {
                newCase.outerColor = 0;
                newCase.outerColorName = ctrl.selected;
                $state.go('cheping.new-detail', {carType: newCase.caseType});
            }
        };

        ctrl.buttonEnable = function() {
            return ctrl.selected;
        };
    })
    .controller('NewLicenseTimeCtrl', function($scope, $state, $stateParams, $timeout, CaseCreateService) {
        var ctrl = this;
        var newCase = CaseCreateService.getNewCase();

        ctrl.date = newCase.licenseTime;

        ctrl.selectConfirm = function() {
            if (ctrl.date) {
                newCase.licenseTime = ctrl.date;
                $state.go('cheping.new-detail', {carType: newCase.caseType});
            }
        };

        ctrl.buttonEnable = function() {
            return ctrl.date;
        };

    })
    .controller('NewFactoryTimeCtrl', function($scope, $state, $stateParams, $timeout, CaseCreateService) {
        var ctrl = this;
        var newCase = CaseCreateService.getNewCase();

        ctrl.date = newCase.factoryTime;

        ctrl.selectConfirm = function() {
            if (ctrl.date) {
                newCase.factoryTime = ctrl.date;
                $state.go('cheping.new-detail', {carType: newCase.caseType});
            }
        };

        ctrl.buttonEnable = function() {
            return ctrl.date;
        };

    })
    .controller('NewVehicleLocationCtrl', function($scope, $state, $stateParams, $timeout, CaseCreateService) {
        var ctrl = this;
        var newCase = CaseCreateService.getNewCase();

        ctrl.groups = CaseCreateService.getCitis();

        ctrl.select = function(cityId) {
            newCase.vehicleLocation = cityId;

            if (newCase.vehicleLocation) {
                $state.go('cheping.new-detail', {carType: newCase.caseType});
            }

        };

        ctrl.toggleGroup = function(group) {
            if (ctrl.isGroupShown(group)) {
                ctrl.shownGroup = null;
            } else {
                ctrl.shownGroup = group;
            }
        };
        ctrl.isGroupShown = function(group) {
            return ctrl.shownGroup === group;
        };
    })
    .controller('NewLicenseLocationCtrl', function($scope, $state, $stateParams, $timeout, CaseCreateService) {
        var ctrl = this;
        var newCase = CaseCreateService.getNewCase();

        ctrl.groups = CaseCreateService.getCitis();

        ctrl.select = function(cityId) {
            newCase.licenseLocation = cityId;

            if (newCase.licenseLocation) {
                $state.go('cheping.new-detail', {carType: newCase.caseType});
            }

        };

        ctrl.toggleGroup = function(group) {
            if (ctrl.isGroupShown(group)) {
                ctrl.shownGroup = null;
            } else {
                ctrl.shownGroup = group;
            }
        };
        ctrl.isGroupShown = function(group) {
            return ctrl.shownGroup === group;
        };
    })
    .controller('NewDisplayMileageCtrl', function($scope, $state, $stateParams, $timeout, CaseCreateService) {
        var ctrl = this;
        var newCase = CaseCreateService.getNewCase();

        ctrl.number = newCase.displayMileage;

        ctrl.selectConfirm = function() {
            if (ctrl.number) {
                newCase.displayMileage = ctrl.number;
                $state.go('cheping.new-detail', {carType: newCase.caseType});
            }
        };

        ctrl.buttonEnable = function() {
            return ctrl.number;
        };

    })
    .controller('NewCooperationMethodCtrl', function($scope, $state, $stateParams, $timeout, CaseCreateService) {
        var ctrl = this;
        var newCase = CaseCreateService.getNewCase();

        ctrl.items = CaseCreateService.getCooperationMethod();
        ctrl.selected = newCase.cooperationMethod;

        ctrl.select = function(item) {
            ctrl.selected = item;
        };

        ctrl.selectConfirm = function() {
            if (ctrl.selected && ctrl.selected !== newCase.cooperationMethod) {
                newCase.cooperationMethod = ctrl.selected;
                $state.go('cheping.new-detail', {carType: newCase.caseType});
            }
        };

        $scope.$watch(angular.bind(ctrl, function() {
            return this.selected;
        }), function(newVal, oldVal) {
            ctrl.selectConfirm();
        });

    })
    .controller('NewExpectedPriceCtrl', function($scope, $state, $stateParams, $timeout, CaseCreateService) {
        var ctrl = this;
        var newCase = CaseCreateService.getNewCase();

        ctrl.number = newCase.expectedPrice;

        ctrl.selectConfirm = function() {
            if (ctrl.number) {
                newCase.expectedPrice = ctrl.number;
                $state.go('cheping.new-detail', {carType: newCase.caseType});
            }
        };

        ctrl.buttonEnable = function() {
            return ctrl.number;
        };

    })
    .controller('NewModifiedContentCtrl', function($scope, $state, $stateParams, $timeout, CaseCreateService) {
        var ctrl = this;
        var newCase = CaseCreateService.getNewCase();

        ctrl.content = newCase.modifiedContent;

        ctrl.selectConfirm = function() {
            if (ctrl.content) {
                newCase.modifiedContent = ctrl.content;
                $state.go('cheping.new-detail', {carType: newCase.caseType});
            }
        };

        ctrl.buttonEnable = function() {
            return ctrl.content;
        };

    });
