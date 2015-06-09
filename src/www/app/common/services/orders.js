angular.module('cheping.services.orders', [
    'cheping.services.cache'
])
    .service('ChepingOrderService', function(ChepingCacheService, ChepingAuthService) {
        var service = this;

        var cacheStorage = ChepingCacheService.get('storage');
        var newOrder;
        var defaultOrder = {
            orderNo: '',
            orderTime: '',
            carType: '跑车',
            brand: '',
            model: '',
            serial: '',
            year: 0,
            color: '',
            innerColor: '',
            carPlateDate: '',
            province: '',
            city: '',
            drivingMileage: 0,
            cooperation: '1973',
            productionDate: '',
            carPlateCity: '',
            expectedPrice: 0,
            tradePrice: 0,
            modified: '',
            images: [],
            vin: '',
            insuranceNo: '',
            commercialRiskNo: '',
            carPlateNo: '',
            orderType: '普通',
            state: 1,
            vehicleInspectionNote: '',
            thumbnail: 'assets/img/LaFerrari_2.jpg'
        };

        var orders = [];

        service.getOrder = function(orderNo){
            return _.find(orders, function(order) {
                return order.orderNo === orderNo;
            })
        };

        service.getOrders = function() {
            return orders || [];
        };

        service.getTodos = function() {

        };

        service.createOrder = function() {
            orders.push(newOrder);
            service.resetNewOrder();
        };

        service.getNewOrder = function() {
            if(!newOrder.orderNo){
                var user = ChepingAuthService.getUser();
                var time = moment().format('YYYYMMDDHHmmSS');
                newOrder.orderNo = user.cityNo + user.outletNo + user.employeeNo + time;
            }
            return newOrder;
        };

        service.resetNewOrder = function() {
            newOrder = defaultOrder;
        };

        service.updateOrder = function(order){
            var index = _.findIndex(orders, function (b) {
                return b.orderNo == order.orderNo
            });

            orders[index] = order;
        };

        service.resetNewOrder();
    });