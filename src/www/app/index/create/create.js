angular.module('cheping.index.create', [
    'cheping.services.orders'
])
    .config(function ($stateProvider) {
        $stateProvider
            .state('cheping.index.create', {
                url: '/create',
                views: {
                    'index.create': {
                        controller: 'CreateCtrl as createCtrl',
                        templateUrl: 'app/index/create/create-index.tpl.html'
                    }
                }
            })
            .state('cheping.index.createDetail', {
                url: '/create/{carType}',
                views: {
                    'index.create': {
                        controller: 'CreateDetailCtrl as createDetailCtrl',
                        templateUrl: 'app/index/create/create-detail.tpl.html'
                    }
                }
            }).state('cheping.index.createDetail-brand', {
                url: '/create/brand',
                views: {
                    'index.create': {
                        controller: 'CreateDetailBrandCtrl as createDetailBrandCtrl',
                        templateUrl: 'app/index/create/create-brand.tpl.html'
                    }
                }
            }).state('cheping.index.createDetail-serial', {
                url: '/create/serial',
                views: {
                    'index.create': {
                        controller: 'CreateDetailSerialCtrl as createDetailSerialCtrl',
                        templateUrl: 'app/index/create/create-serial.tpl.html'
                    }
                }
            }).state('cheping.index.createDetail-model', {
                url: '/create/model',
                views: {
                    'index.create': {
                        controller: 'CreateDetailModelCtrl as createDetailModelCtrl',
                        templateUrl: 'app/index/create/create-model.tpl.html'
                    }
                }
            }).state('cheping.index.createDetail-color', {
                url: '/create/color',
                views: {
                    'index.create': {
                        controller: 'CreateDetailColorCtrl as createDetailColorCtrl',
                        templateUrl: 'app/index/create/create-color.tpl.html'
                    }
                }
            }).state('cheping.index.createDetail-inner-color', {
                url: '/create/inner-color',
                views: {
                    'index.create': {
                        controller: 'CreateDetailInnerColorCtrl as createDetailInnerColorCtrl',
                        templateUrl: 'app/index/create/create-inner-color.tpl.html'
                    }
                }
            }).state('cheping.index.createDetail-city', {
                url: '/create/city',
                views: {
                    'index.create': {
                        controller: 'CreateDetailCityCtrl as createDetailCityCtrl',
                        templateUrl: 'app/index/create/create-city.tpl.html'
                    }
                }
            }).state('cheping.index.createDetail-driving', {
                url: '/create/driving',
                views: {
                    'index.create': {
                        controller: 'CreateDetailDrivingCtrl as createDetailDrivingCtrl',
                        templateUrl: 'app/index/create/create-driving.tpl.html'
                    }
                }
            }).state('cheping.index.createDetail-cooperation', {
                url: '/create/cooperation',
                views: {
                    'index.create': {
                        controller: 'CreateDetailCooperationCtrl as createDetailCooperationCtrl',
                        templateUrl: 'app/index/create/create-cooperation.tpl.html'
                    }
                }
            }).state('cheping.index.createDetail-content', {
                url: '/create/content',
                views: {
                    'index.create': {
                        controller: 'CreateDetailContentCtrl as createDetailContentCtrl',
                        templateUrl: 'app/index/create/create-content.tpl.html'
                    }
                }
            });
    })
    .controller('CreateCtrl', function() {
        var createCtrl = this;
        createCtrl.ordes = [];

    })
    .controller('CreateDetailCtrl', function($state, $stateParams, ChepingOrderService) {
        var createDetailCtrl = this;
        var newOrder = ChepingOrderService.getNewOrder();

        newOrder.carType = $stateParams.carType;

        createDetailCtrl.newOrder = newOrder;

        createDetailCtrl.goBack = function(){
            $state.go('cheping.index.create');
        };

        createDetailCtrl.create = function(){
            ChepingOrderService.createOrder();
            $state.go('cheping.index.orders');
        };

        createDetailCtrl.reset = function(){
            ChepingOrderService.resetNewOrder();
            $state.go('cheping.index.orders');
        };

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
