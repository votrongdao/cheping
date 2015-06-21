angular.module('cheping.new.detail', [
    'cheping.services.caseCreate',
    'ngCordova',
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
            //}).state('cheping.index.createDetail-city', {
            //    url: '/create/city',
            //    views: {
            //        'index.create': {
            //            controller: 'CreateDetailCityCtrl as createDetailCityCtrl',
            //            templateUrl: 'app/index/create/create-city.tpl.html'
            //        }
            //    }
            //}).state('cheping.index.createDetail-driving', {
            //    url: '/create/driving',
            //    views: {
            //        'index.create': {
            //            controller: 'CreateDetailDrivingCtrl as createDetailDrivingCtrl',
            //            templateUrl: 'app/index/create/create-driving.tpl.html'
            //        }
            //    }
            //}).state('cheping.index.createDetail-cooperation', {
            //    url: '/create/cooperation',
            //    views: {
            //        'index.create': {
            //            controller: 'CreateDetailCooperationCtrl as createDetailCooperationCtrl',
            //            templateUrl: 'app/index/create/create-cooperation.tpl.html'
            //        }
            //    }
            //}).state('cheping.index.createDetail-content', {
            //    url: '/create/content',
            //    views: {
            //        'index.create': {
            //            controller: 'CreateDetailContentCtrl as createDetailContentCtrl',
            //            templateUrl: 'app/index/create/create-content.tpl.html'
            //        }
            //    }
            //});
        ;
    })
    .controller('NewCtrl', function($scope, $stateParams, CaseCreateService) {
        var _case = this;

        _case.viewModel = {};

        var newCase = CaseCreateService.getNewCase();
        if (newCase.caseType !== $stateParams.carType) {
            newCase = CaseCreateService.resetNewCase($stateParams.carType);
        }

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

        ctrl.select = function(item) {
            ctrl.selected = item;
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

        ctrl.select = function(item) {
            ctrl.selected = item;
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

        ctrl.items = [];
        ctrl.selected = newCase.outerColor;

        ctrl.loadItems = function() {
            ctrl.items = CaseCreateService.getColors();
        };

        ctrl.select = function(item) {
            ctrl.selected = item;
        };

        ctrl.selectConfirm = function() {
            if (ctrl.selected && ctrl.selected !== newCase.outerColor) {
                newCase.outerColor = ctrl.selected;
                $state.go('cheping.new-detail', {carType: newCase.caseType});
            }
        };

        ctrl.buttonEnable = function() {
            return ctrl.selected;
        };

        ctrl.loadItems();

        $scope.$watch(angular.bind(ctrl, function () {
            return this.selected;
        }), function (newVal, oldVal) {
            ctrl.selectConfirm();
        });

    })
    .controller('NewInnerColorCtrl', function($scope, $state, $stateParams, $timeout, CaseCreateService) {
        var ctrl = this;
        var newCase = CaseCreateService.getNewCase();

        ctrl.items = [];
        ctrl.selected = newCase.innerColor;

        ctrl.loadItems = function() {
            ctrl.items = CaseCreateService.getColors();
        };

        ctrl.select = function(item) {
            ctrl.selected = item;
        };

        ctrl.selectConfirm = function() {
            if (ctrl.selected && ctrl.selected !== newCase.innerColor) {
                newCase.innerColor = ctrl.selected;
                $state.go('cheping.new-detail', {carType: newCase.caseType});
            }
        };

        ctrl.buttonEnable = function() {
            return ctrl.selected;
        };

        ctrl.loadItems();

        $scope.$watch(angular.bind(ctrl, function () {
            return this.selected;
        }), function (newVal, oldVal) {
            ctrl.selectConfirm();
        });

    })
    .controller('NewLicenseTimeCtrl', function($scope, $state, $stateParams, $timeout, CaseCreateService) {
        var ctrl = this;
        var newOrder = CaseCreateService.getNewCase();

        ctrl.date = '';

        ctrl.selectConfirm = function() {
            if (ctrl.date) {
                newOrder.licenseTime = ctrl.date;
                $state.go('cheping.new-detail', {carType: newOrder.caseType});
            }
        };

        ctrl.buttonEnable = function() {
            return ctrl.date;
        };

    })
    .controller('NewFactoryTimeCtrl', function($scope, $state, $stateParams, $timeout, CaseCreateService) {
        var ctrl = this;
        var newOrder = CaseCreateService.getNewCase();

        ctrl.date = '';

        ctrl.selectConfirm = function() {
            if (ctrl.date) {
                newOrder.factoryTime = ctrl.date;
                $state.go('cheping.new-detail', {carType: newOrder.caseType});
            }
        };

        ctrl.buttonEnable = function() {
            return ctrl.date;
        };

    })
    .controller('NewVehicleLocationCtrl', function($scope, $state, $stateParams, $timeout, CaseCreateService) {
        var ctrl = this;
        var newCase = CaseCreateService.getNewCase();

        ctrl.groups = [];


        ctrl.items = [];
        ctrl.selected = newCase.vehicleLocation;

        ctrl.loadItems = function() {
            ctrl.items = CaseCreateService.getColors();
        };

        ctrl.select = function(item) {
            ctrl.selected = item;
        };

        ctrl.selectConfirm = function() {
            if (ctrl.selected && ctrl.selected !== newCase.vehicleLocation) {
                newCase.vehicleLocation = ctrl.selected;
                $state.go('cheping.new-detail', {carType: newCase.caseType});
            }
        };

        ctrl.buttonEnable = function() {
            return ctrl.selected;
        };

        ctrl.loadItems();

        $scope.$watch(angular.bind(ctrl, function () {
            return this.selected;
        }), function (newVal, oldVal) {
            ctrl.selectConfirm();
        });
    })
    .controller('CreateDetailCooperationCtrl', function($state, ChepingOrderService) {
        var createDetailCooperationCtrl = this;
        var newOrder = ChepingOrderService.getNewOrder();
        createDetailCooperationCtrl.newOrder = newOrder;

        createDetailCooperationCtrl.items = [
            '1973',
            '自销'
        ];

        createDetailCooperationCtrl.goBack = function() {
            $state.go('cheping.index.createDetail', {carType: newOrder.carType})
        }

    })
    .controller('CreateDetailInnerColorCtrl', function($state, ChepingOrderService) {
        var createDetailInnerColorCtrl = this;
        var newOrder = ChepingOrderService.getNewOrder();
        createDetailInnerColorCtrl.newOrder = newOrder;

        createDetailInnerColorCtrl.items = [
            '白色',
            '黑色',
            '灰色',
            '红色',
            '银色'
        ];

        createDetailInnerColorCtrl.goBack = function() {
            $state.go('cheping.index.createDetail', {carType: newOrder.carType})
        }

    })
    .controller('CreateDetailCityCtrl', function($state, ChepingOrderService) {
        var createDetailCityCtrl = this;
        var newOrder = ChepingOrderService.getNewOrder();
        createDetailCityCtrl.newOrder = newOrder;

        createDetailCityCtrl.items = [
            '北京',
            '上海',
            '杭州',
            '南京',
            '深圳'
        ];

        createDetailCityCtrl.goBack = function() {
            $state.go('cheping.index.createDetail', {carType: newOrder.carType})
        }

    })
    .controller('CreateDetailDrivingCtrl', function($state, ChepingOrderService) {
        var createDetailDrivingCtrl = this;
        var newOrder = ChepingOrderService.getNewOrder();
        createDetailDrivingCtrl.newOrder = newOrder;


        createDetailDrivingCtrl.goBack = function() {
            $state.go('cheping.index.createDetail', {carType: newOrder.carType})
        }

    })
    .controller('CreateDetailContentCtrl', function($state, ChepingOrderService) {
        var createDetailContentCtrl = this;
        var newOrder = ChepingOrderService.getNewOrder();
        createDetailContentCtrl.newOrder = newOrder;


        createDetailContentCtrl.goBack = function() {
            $state.go('cheping.index.createDetail', {carType: newOrder.carType})
        }

    });
