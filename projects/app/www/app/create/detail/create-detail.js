angular.module('cheping.new.detail', [
    'cheping.services.caseCreate',
    'ngCordova',
])
    .config(function ($stateProvider) {
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
            .state('cheping.new-factory-time', {
                url: '/new/factory-time',
                views: {
                    'new': {
                        controller: 'NewFactoryTimeCtrl as ctrl',
                        templateUrl: 'app/create/detail/create-detail-factory-time.tpl.html'
                    }
                }
            })
            //.state('cheping.index.createDetail-brand', {
            //    url: '/create/brand',
            //    views: {
            //        'index.create': {
            //            controller: 'CreateDetailBrandCtrl as createDetailBrandCtrl',
            //            templateUrl: 'app/index/create/create-brand.tpl.html'
            //        }
            //    }
            //}).state('cheping.index.createDetail-serial', {
            //    url: '/create/serial',
            //    views: {
            //        'index.create': {
            //            controller: 'CreateDetailSerialCtrl as createDetailSerialCtrl',
            //            templateUrl: 'app/index/create/create-serial.tpl.html'
            //        }
            //    }
            //}).state('cheping.index.createDetail-model', {
            //    url: '/create/model',
            //    views: {
            //        'index.create': {
            //            controller: 'CreateDetailModelCtrl as createDetailModelCtrl',
            //            templateUrl: 'app/index/create/create-model.tpl.html'
            //        }
            //    }
            //}).state('cheping.index.createDetail-color', {
            //    url: '/create/color',
            //    views: {
            //        'index.create': {
            //            controller: 'CreateDetailColorCtrl as createDetailColorCtrl',
            //            templateUrl: 'app/index/create/create-color.tpl.html'
            //        }
            //    }
            //}).state('cheping.index.createDetail-inner-color', {
            //    url: '/create/inner-color',
            //    views: {
            //        'index.create': {
            //            controller: 'CreateDetailInnerColorCtrl as createDetailInnerColorCtrl',
            //            templateUrl: 'app/index/create/create-inner-color.tpl.html'
            //        }
            //    }
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
        if(newCase.caseType !== $stateParams.carType) {
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

        ctrl.brands = [];
        ctrl.selected = newCase.brandName;

        ctrl.loadBrands = function() {
            CaseCreateService.getBrands()
                .then(function(result) {
                    ctrl.brands = result;
                });
        };

        ctrl.select = function(item) {
            ctrl.selected = item;
        };

        ctrl.selectConfirm = function() {
            if(ctrl.selected) {
                newCase.brandName = ctrl.selected;
                $state.go('cheping.new-detail', { carType: newCase.caseType });
            }
        };

        ctrl.buttonEnable = function() {
            return ctrl.selected;
        };

        ctrl.doRefresh = function() {
            ctrl.loadBrands();

            $timeout(function() {
                $scope.$broadcast('scroll.refreshComplete');
            }, 500);
        };

        ctrl.loadBrands();

    })
    .controller('NewFactoryTimeCtrl', function($scope, $state, $stateParams, $timeout, CaseCreateService) {
        var ctrl = this;
        var newOrder = CaseCreateService.getNewCase();

        ctrl.date = '';

        ctrl.selectConfirm = function() {
            if(ctrl.date) {
                newOrder.factoryTime = ctrl.date;
                $state.go('cheping.new-detail', { carType: newOrder.caseType });
            }
        };

        ctrl.buttonEnable = function() {
            return ctrl.date;
        };

    })
    .controller('CreateDetailColorCtrl', function($state, ChepingOrderService) {
        var createDetailColorCtrl = this;
        var newOrder = ChepingOrderService.getNewOrder();
        createDetailColorCtrl.newOrder = newOrder;

        createDetailColorCtrl.items = [
            '白色',
            '黑色',
            '灰色',
            '红色',
            '银色'
        ];

        createDetailColorCtrl.goBack = function(){
            $state.go('cheping.index.createDetail', {carType: newOrder.carType})
        }

    })
    .controller('CreateDetailCooperationCtrl', function($state, ChepingOrderService) {
        var createDetailCooperationCtrl = this;
        var newOrder = ChepingOrderService.getNewOrder();
        createDetailCooperationCtrl.newOrder = newOrder;

        createDetailCooperationCtrl.items = [
            '1973',
            '自销'
        ];

        createDetailCooperationCtrl.goBack = function(){
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

        createDetailInnerColorCtrl.goBack = function(){
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

        createDetailCityCtrl.goBack = function(){
            $state.go('cheping.index.createDetail', {carType: newOrder.carType})
        }

    })
    .controller('CreateDetailDrivingCtrl', function($state, ChepingOrderService) {
        var createDetailDrivingCtrl = this;
        var newOrder = ChepingOrderService.getNewOrder();
        createDetailDrivingCtrl.newOrder = newOrder;


        createDetailDrivingCtrl.goBack = function(){
            $state.go('cheping.index.createDetail', {carType: newOrder.carType})
        }

    })
    .controller('CreateDetailContentCtrl', function($state, ChepingOrderService) {
        var createDetailContentCtrl = this;
        var newOrder = ChepingOrderService.getNewOrder();
        createDetailContentCtrl.newOrder = newOrder;


        createDetailContentCtrl.goBack = function(){
            $state.go('cheping.index.createDetail', {carType: newOrder.carType})
        }

    });
