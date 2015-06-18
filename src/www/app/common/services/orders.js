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

        var orders = [{
          "orderNo": "00101217220150608215852",
          "orderTime": "2015-06-08 21:58:52",
          "carType": 0,
          "brandId": 112,
          "brand": "·��",
          "modelId": 18181,
          "model": "2011�� ����4 2.7T �Զ� ���� S ����",
          "serialId": 754,
          "serial": "����",
          "year": 2011,
          "color": "��ɫ",
          "innerColor": "��ɫ",
          "carPlateDate": "2011-05-09 00:00:00",
          "province": "�Ϻ�",
          "city": "�Ϻ�",
          "drivingMileage": 321,
          "cooperation": "1973",
          "productionDate": "2010-09-23 00:00:00",
          "carPlateCity": "�Ϻ�",
          "expectedPrice": 200000,
          "tradePrice": 630000,
          "modified": "��",
          "images": [],
          "vin": "LSVNN2180D2013488",
          "insuranceNo": "11638001900017060023",
          "commercialRiskNo": "11638001900017060024",
          "carPlateNo": "��F1234",
          "orderType": "��ͨ",
          "state": 1,
          "vehicleInspectionNote": ""
        },
          {
            "orderNo": "00101217220150608215852",
            "orderTime": "2015-06-08 21:58:52",
            "carType": 0,
            "brandId": 112,
            "brand": "·��",
            "modelId": 18181,
            "model": "2011�� ����4 2.7T �Զ� ���� S ����",
            "serialId": 754,
            "serial": "����",
            "year": 2011,
            "color": "��ɫ",
            "innerColor": "��ɫ",
            "carPlateDate": "2011-05-09 00:00:00",
            "province": "�Ϻ�",
            "city": "�Ϻ�",
            "drivingMileage": 321,
            "cooperation": "1973",
            "productionDate": "2010-09-23 00:00:00",
            "carPlateCity": "�Ϻ�",
            "expectedPrice": 200000,
            "tradePrice": 630000,
            "modified": "��",
            "images": [],
            "vin": "LSVNN2180D2013488",
            "insuranceNo": "11638001900017060023",
            "commercialRiskNo": "11638001900017060024",
            "carPlateNo": "��F1234",
            "orderType": "��ͨ",
            "state": 1,
            "vehicleInspectionNote": ""
          },
          {
            "orderNo": "00101217220150608215852",
            "orderTime": "2015-06-08 21:58:52",
            "carType": 0,
            "brandId": 112,
            "brand": "·��",
            "modelId": 18181,
            "model": "2011�� ����4 2.7T �Զ� ���� S ����",
            "serialId": 754,
            "serial": "����",
            "year": 2011,
            "color": "��ɫ",
            "innerColor": "��ɫ",
            "carPlateDate": "2011-05-09 00:00:00",
            "province": "�Ϻ�",
            "city": "�Ϻ�",
            "drivingMileage": 321,
            "cooperation": "1973",
            "productionDate": "2010-09-23 00:00:00",
            "carPlateCity": "�Ϻ�",
            "expectedPrice": 200000,
            "tradePrice": 630000,
            "modified": "��",
            "images": [],
            "vin": "LSVNN2180D2013488",
            "insuranceNo": "11638001900017060023",
            "commercialRiskNo": "11638001900017060024",
            "carPlateNo": "��F1234",
            "orderType": "��ͨ",
            "state": 1,
            "vehicleInspectionNote": ""
          },
          {
            "orderNo": "00101217220150608215852",
            "orderTime": "2015-06-08 21:58:52",
            "carType": 0,
            "brandId": 112,
            "brand": "·��",
            "modelId": 18181,
            "model": "2011�� ����4 2.7T �Զ� ���� S ����",
            "serialId": 754,
            "serial": "����",
            "year": 2011,
            "color": "��ɫ",
            "innerColor": "��ɫ",
            "carPlateDate": "2011-05-09 00:00:00",
            "province": "�Ϻ�",
            "city": "�Ϻ�",
            "drivingMileage": 321,
            "cooperation": "1973",
            "productionDate": "2010-09-23 00:00:00",
            "carPlateCity": "�Ϻ�",
            "expectedPrice": 200000,
            "tradePrice": 630000,
            "modified": "��",
            "images": [],
            "vin": "LSVNN2180D2013488",
            "insuranceNo": "11638001900017060023",
            "commercialRiskNo": "11638001900017060024",
            "carPlateNo": "��F1234",
            "orderType": "��ͨ",
            "state": 1,
            "vehicleInspectionNote": ""
          },
          {
            "orderNo": "00101217220150608215852",
            "orderTime": "2015-06-08 21:58:52",
            "carType": 0,
            "brandId": 112,
            "brand": "·��",
            "modelId": 18181,
            "model": "2011�� ����4 2.7T �Զ� ���� S ����",
            "serialId": 754,
            "serial": "����",
            "year": 2011,
            "color": "��ɫ",
            "innerColor": "��ɫ",
            "carPlateDate": "2011-05-09 00:00:00",
            "province": "�Ϻ�",
            "city": "�Ϻ�",
            "drivingMileage": 321,
            "cooperation": "1973",
            "productionDate": "2010-09-23 00:00:00",
            "carPlateCity": "�Ϻ�",
            "expectedPrice": 200000,
            "tradePrice": 630000,
            "modified": "��",
            "images": [],
            "vin": "LSVNN2180D2013488",
            "insuranceNo": "11638001900017060023",
            "commercialRiskNo": "11638001900017060024",
            "carPlateNo": "��F1234",
            "orderType": "��ͨ",
            "state": 1,
            "vehicleInspectionNote": ""
          },
          {
            "orderNo": "00101217220150608215852",
            "orderTime": "2015-06-08 21:58:52",
            "carType": 0,
            "brandId": 112,
            "brand": "·��",
            "modelId": 18181,
            "model": "2011�� ����4 2.7T �Զ� ���� S ����",
            "serialId": 754,
            "serial": "����",
            "year": 2011,
            "color": "��ɫ",
            "innerColor": "��ɫ",
            "carPlateDate": "2011-05-09 00:00:00",
            "province": "�Ϻ�",
            "city": "�Ϻ�",
            "drivingMileage": 321,
            "cooperation": "1973",
            "productionDate": "2010-09-23 00:00:00",
            "carPlateCity": "�Ϻ�",
            "expectedPrice": 200000,
            "tradePrice": 630000,
            "modified": "��",
            "images": [],
            "vin": "LSVNN2180D2013488",
            "insuranceNo": "11638001900017060023",
            "commercialRiskNo": "11638001900017060024",
            "carPlateNo": "��F1234",
            "orderType": "��ͨ",
            "state": 1,
            "vehicleInspectionNote": ""
          },
          {
            "orderNo": "00101217220150608215852",
            "orderTime": "2015-06-08 21:58:52",
            "carType": 0,
            "brandId": 112,
            "brand": "·��",
            "modelId": 18181,
            "model": "2011�� ����4 2.7T �Զ� ���� S ����",
            "serialId": 754,
            "serial": "����",
            "year": 2011,
            "color": "��ɫ",
            "innerColor": "��ɫ",
            "carPlateDate": "2011-05-09 00:00:00",
            "province": "�Ϻ�",
            "city": "�Ϻ�",
            "drivingMileage": 321,
            "cooperation": "1973",
            "productionDate": "2010-09-23 00:00:00",
            "carPlateCity": "�Ϻ�",
            "expectedPrice": 200000,
            "tradePrice": 630000,
            "modified": "��",
            "images": [],
            "vin": "LSVNN2180D2013488",
            "insuranceNo": "11638001900017060023",
            "commercialRiskNo": "11638001900017060024",
            "carPlateNo": "��F1234",
            "orderType": "��ͨ",
            "state": 1,
            "vehicleInspectionNote": ""
          },
          {
            "orderNo": "00101217220150608215852",
            "orderTime": "2015-06-08 21:58:52",
            "carType": 0,
            "brandId": 112,
            "brand": "·��",
            "modelId": 18181,
            "model": "2011�� ����4 2.7T �Զ� ���� S ����",
            "serialId": 754,
            "serial": "����",
            "year": 2011,
            "color": "��ɫ",
            "innerColor": "��ɫ",
            "carPlateDate": "2011-05-09 00:00:00",
            "province": "�Ϻ�",
            "city": "�Ϻ�",
            "drivingMileage": 321,
            "cooperation": "1973",
            "productionDate": "2010-09-23 00:00:00",
            "carPlateCity": "�Ϻ�",
            "expectedPrice": 200000,
            "tradePrice": 630000,
            "modified": "��",
            "images": [],
            "vin": "LSVNN2180D2013488",
            "insuranceNo": "11638001900017060023",
            "commercialRiskNo": "11638001900017060024",
            "carPlateNo": "��F1234",
            "orderType": "��ͨ",
            "state": 1,
            "vehicleInspectionNote": ""
          }];

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