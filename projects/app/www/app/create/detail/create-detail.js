angular.module('cheping.new.detail', [
    'cheping.services.caseCreate'
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
    .controller('NewCtrl', function($stateParams, CaseCreateService) {
        var _case = this;

        _case.viewModel = {};
        CaseCreateService.resetNewCase($stateParams.carType);

        var newCase = CaseCreateService.getNewCase();

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

        _case.resetViewModel();

    })
    .controller('NewBrandCtrl', function($scope, $state, $stateParams, $timeout, CaseCreateService) {
        var ctrl = this;
        var newOrder = CaseCreateService.getNewCase();

        ctrl.brands = [];
        ctrl.selected = '';

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
                newOrder.brandName = ctrl.selected;
                $state.go('cheping.new-detail', { carType: newOrder.caseType });
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
    .controller('CreateDetailBrandCtrl', function($state, ChepingOrderService) {
        var createDetailBrandCtrl = this;
        var newOrder = ChepingOrderService.getNewOrder();
        createDetailBrandCtrl.newOrder = newOrder;

        createDetailBrandCtrl.items = [
            'AC Schnitzer',
            'GMC',
            'KTM',
            'Spirra',
            '三菱',
            '中欧',
            '丰田',
            '保时捷',
            '光冈',
            '克莱斯勒',
            '兰博基尼',
            '凯佰赫',
            '凯迪拉克',
            '别克',
            '宾利',
            '巴博斯',
            '布加迪',
            '捷豹',
            '摩根',
            '斯巴鲁',
            '斯柯达',
            '日产',
            '本田',
            '林肯',
            '柯尼赛格',
            '标致',
            '欧宝',
            '比亚迪',
            '沃尔沃',
            '法拉利',
            '起亚',
            '路特斯',
            '路虎',
            '迈凯轮',
            '迈巴赫',
            '迷你',
            '道奇',
            '阿斯顿马丁',
            '雪佛兰',
            '雪铁龙',
            '雷克萨斯',
            '雷诺',
            '马自达'
        ];

        createDetailBrandCtrl.goBack = function(){
            $state.go('cheping.index.createDetail', {carType: newOrder.carType})
        }

    })
    .controller('CreateDetailSerialCtrl', function($state, ChepingOrderService) {
        var createDetailSerialCtrl = this;
        var newOrder = ChepingOrderService.getNewOrder();
        createDetailSerialCtrl.newOrder = newOrder;

        createDetailSerialCtrl.items = [
            'S5',
            'S6',
            'S7',
            'Savana',
            '西拉',
            'Terrain',
            'X-BOW',
            'Spirra',
            '欧蓝德',
            '帕杰罗',
            '伊柯丽斯',
            '帕杰罗劲畅',
            '尊逸',
            '锐志',
            '普拉多',
            '普锐斯',
            '凯美瑞',
            'FJ酷路泽',
            '埃尔法',
            'RAV4',
            '塞纳',
            '坦途',
            '柯斯达',
            '皇冠',
            '海狮 ',
            '红杉',
            '考斯特',
            '汉兰达',
            '陆地巡洋舰',
            '普瑞维亚',
            '威飒',
            '兰德酷路泽',
            'Hilux',
            '911',
            '911 敞篷车',
            '卡宴',
            '卡曼',
            'Panamera',
            'CX-9'
        ];

        createDetailSerialCtrl.goBack = function(){
            $state.go('cheping.index.createDetail', {carType: newOrder.carType})
        }

    })
    .controller('CreateDetailModelCtrl', function($state, ChepingOrderService) {
        var createDetailModelCtrl = this;
        var newOrder = ChepingOrderService.getNewOrder();
        createDetailModelCtrl.newOrder = newOrder;

        createDetailModelCtrl.items = [
            '2012款 3.0T 自动 猎鹰版 四驱',
            '2010款 3.0L 自动 猎鹰版 四驱',
            '2010款 3.0T 自动 猎鹰版 四驱',
            '2011款 3.0T 自动 四驱',
            '2012款 3.0T 自动 四驱',
            '2010款 5.3L 自动 7座总统级',
            '2007款 6.0L 自动 7座总统级',
            '2010款 6.0L 自动 7座总统级',
            '2011款 6.0L 自动 7座加长领袖级',
            '2012款 6.2L 自动 Denali 四驱',
            '2012款 3.0L 自动 基本型',
            '2011款 5.3L 自动 7座商务之星(欧Ⅳ)',
            '2011款 6.0L 自动 7座商务之星(欧Ⅳ)',
            '2011款 6.0L 自动 10座商务之星(欧Ⅳ)',
            '2012款 6.0L 自动 领袖级经典版(欧Ⅳ)',
            '2012款 6.0L 自动 领袖级至尊版(欧Ⅳ)',
            '2012款 6.0L 自动 总裁级无隐私屏版(欧Ⅳ)',
            '2012款 6.0L 自动 总裁级隐私屏版(欧Ⅳ)',
            '2012款 6.0L 自动 商务之星公爵版(欧Ⅳ)',
            '2012款 6.0L 自动 皇家级(欧Ⅳ)',
            '2013款 5.3L 自动 领袖至尊版(欧Ⅳ)',
            '2013款 6.0L 自动 领袖级商务车(欧Ⅳ)',
            '2013款 6.0L 自动 7座豪华隐私屏版(欧Ⅳ)',
            '2013款 5.3L 自动 总裁级 四驱(欧Ⅳ)',
            '2013款 5.3L 自动 运动版1500 四驱(欧Ⅳ)',
            '2013款 5.3L 自动 领袖版(欧Ⅳ)',
            '2013款 5.3L 自动 领袖版 四驱(欧Ⅳ)',
            '2013款 6.0L 自动 长轴领袖版(欧Ⅳ)',
            '2013款 6.0L 自动 10座七座运动版2500S(欧Ⅳ)',
            '2013款 6.0L 自动 10座运动版2500S(欧Ⅳ)',
            '2013款 6.0L 自动 标准版3500(欧Ⅳ)',
            '2013款 6.0L 自动 舒适版3500(欧Ⅳ)',
            '2014款 5.3L 自动 领袖版(欧Ⅳ)'
        ];

        createDetailModelCtrl.goBack = function(){
            $state.go('cheping.index.createDetail', {carType: newOrder.carType})
        }

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
