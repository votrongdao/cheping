angular.module('cheping.services', [])

  .factory('Orders', function() {
    // Might use a resource here that returns a JSON array

    // Some fake testing data
    var orders = [{
      thumbnail: "./img/demo1.jpg",
      brand: "宝马",
      model: "720 Li",
      province: "上海",
      city: "上海",
      year: "2012",
      color: "黑色",
      innerColor: "灰色",
      orderState: "已审核",
      orderNo: "FT7001251",
      carPlateDate: "2013年5月12日",
      drivingMileage: "1202",
      cooperation: "1973",
      productionDate: "2011年1月1日",
      carPlateCity: "上海",
      expectedPrice: "200.00",
      tradePrice: "200.00",
      modified: "无改装",
      images: ["./img/demo1.jpg", "./img/demo2.jpg"],
      VIN: "LSVNN2180D2013488",
      insuranceNo: "11638001900017060023",
      commercialRiskNo: "11638001900017060024",
      carPlateNo: "沪F1234",
      orderType: "普通",
      vehicleInspectionNote: null
    },{
      thumbnail: "./img/demo1.jpg",
      brand: "宝马",
      model: "720 Li",
      province: "上海",
      city: "上海",
      year: "2012",
      color: "黑色",
      innerColor: "灰色",
      orderState: "已审核",
      orderNo: "FT7001252",
      carPlateDate: "2013年5月12日",
      drivingMileage: "1202",
      cooperation: "1973",
      productionDate: "2011年1月1日",
      carPlateCity: "上海",
      expectedPrice: "200.00",
      tradePrice: "200.00",
      modified: "无改装",
      images: ["./img/demo1.jpg", "./img/demo2.jpg"],
      VIN: "LSVNN2180D2013488",
      insuranceNo: "11638001900017060023",
      commercialRiskNo: "11638001900017060024",
      carPlateNo: "沪F1234",
      orderType: "普通",
      vehicleInspectionNote: null
    },{
      thumbnail: "./img/demo1.jpg",
      brand: "宝马",
      model: "720 Li",
      province: "上海",
      city: "上海",
      year: "2012",
      color: "黑色",
      innerColor: "灰色",
      orderState: "已审核",
      orderNo: "FT7001253",
      carPlateDate: "2013年5月12日",
      drivingMileage: "1202",
      cooperation: "1973",
      productionDate: "2011年1月1日",
      carPlateCity: "上海",
      expectedPrice: "200.00",
      tradePrice: "200.00",
      modified: "无改装",
      images: ["./img/demo1.jpg", "./img/demo2.jpg"],
      VIN: "LSVNN2180D2013488",
      insuranceNo: "11638001900017060023",
      commercialRiskNo: "11638001900017060024",
      carPlateNo: "沪F1234",
      orderType: "普通",
      vehicleInspectionNote: null
    },{
      thumbnail: "./img/demo1.jpg",
      brand: "宝马",
      model: "720 Li",
      province: "上海",
      city: "上海",
      year: "2012",
      color: "黑色",
      innerColor: "灰色",
      orderState: "已审核",
      orderNo: "FT7001254",
      carPlateDate: "2013年5月12日",
      drivingMileage: "1202",
      cooperation: "1973",
      productionDate: "2011年1月1日",
      carPlateCity: "上海",
      expectedPrice: "200.00",
      tradePrice: "200.00",
      modified: "无改装",
      images: ["./img/demo1.jpg", "./img/demo2.jpg"],
      VIN: "LSVNN2180D2013488",
      insuranceNo: "11638001900017060023",
      commercialRiskNo: "11638001900017060024",
      carPlateNo: "沪F1234",
      orderType: "普通",
      vehicleInspectionNote: null
    },{
      thumbnail: "./img/demo1.jpg",
      brand: "宝马",
      model: "720 Li",
      province: "上海",
      city: "上海",
      year: "2012",
      color: "黑色",
      innerColor: "灰色",
      orderState: "已审核",
      orderNo: "FT7001255",
      carPlateDate: "2013年5月12日",
      drivingMileage: "1202",
      cooperation: "1973",
      productionDate: "2011年1月1日",
      carPlateCity: "上海",
      expectedPrice: "200.00",
      tradePrice: "200.00",
      modified: "无改装",
      images: ["./img/demo1.jpg", "./img/demo2.jpg"],
      VIN: "LSVNN2180D2013488",
      insuranceNo: "11638001900017060023",
      commercialRiskNo: "11638001900017060024",
      carPlateNo: "沪F1234",
      orderType: "普通",
      vehicleInspectionNote: null
    },{
      thumbnail: "./img/demo1.jpg",
      brand: "宝马",
      model: "720 Li",
      province: "上海",
      city: "上海",
      year: "2012",
      color: "黑色",
      innerColor: "灰色",
      orderState: "已审核",
      orderNo: "FT7001256",
      carPlateDate: "2013年5月12日",
      drivingMileage: "1202",
      cooperation: "1973",
      productionDate: "2011年1月1日",
      carPlateCity: "上海",
      expectedPrice: "200.00",
      tradePrice: "200.00",
      modified: "无改装",
      images: ["./img/demo1.jpg", "./img/demo2.jpg"],
      VIN: "LSVNN2180D2013488",
      insuranceNo: "11638001900017060023",
      commercialRiskNo: "11638001900017060024",
      carPlateNo: "沪F1234",
      orderType: "普通",
      vehicleInspectionNote: null
    },{
      thumbnail: "./img/demo1.jpg",
      brand: "宝马",
      model: "720 Li",
      province: "上海",
      city: "上海",
      year: "2012",
      color: "黑色",
      innerColor: "灰色",
      orderState: "已审核",
      orderNo: "FT7001257",
      carPlateDate: "2013年5月12日",
      drivingMileage: "1202",
      cooperation: "1973",
      productionDate: "2011年1月1日",
      carPlateCity: "上海",
      expectedPrice: "200.00",
      tradePrice: "200.00",
      modified: "无改装",
      images: ["./img/demo1.jpg", "./img/demo2.jpg"],
      VIN: "LSVNN2180D2013488",
      insuranceNo: "11638001900017060023",
      commercialRiskNo: "11638001900017060024",
      carPlateNo: "沪F1234",
      orderType: "普通",
      vehicleInspectionNote: null
    },{
      thumbnail: "./img/demo1.jpg",
      brand: "宝马",
      model: "720 Li",
      province: "上海",
      city: "上海",
      year: "2012",
      color: "黑色",
      innerColor: "灰色",
      orderState: "已审核",
      orderNo: "FT7001258",
      carPlateDate: "2013年5月12日",
      drivingMileage: "1202",
      cooperation: "1973",
      productionDate: "2011年1月1日",
      carPlateCity: "上海",
      expectedPrice: "200.00",
      tradePrice: "200.00",
      modified: "无改装",
      images: ["./img/demo1.jpg", "./img/demo2.jpg"],
      VIN: "LSVNN2180D2013488",
      insuranceNo: "11638001900017060023",
      commercialRiskNo: "11638001900017060024",
      carPlateNo: "沪F1234",
      orderType: "普通",
      vehicleInspectionNote: null
    },{
      thumbnail: "./img/demo1.jpg",
      brand: "宝马",
      model: "720 Li",
      province: "上海",
      city: "上海",
      year: "2012",
      color: "黑色",
      innerColor: "灰色",
      orderState: "已审核",
      orderNo: "FT7001259",
      carPlateDate: "2013年5月12日",
      drivingMileage: "1202",
      cooperation: "1973",
      productionDate: "2011年1月1日",
      carPlateCity: "上海",
      expectedPrice: "200.00",
      tradePrice: "200.00",
      modified: "无改装",
      images: ["./img/demo1.jpg", "./img/demo2.jpg"],
      VIN: "LSVNN2180D2013488",
      insuranceNo: "11638001900017060023",
      commercialRiskNo: "11638001900017060024",
      carPlateNo: "沪F1234",
      orderType: "普通",
      vehicleInspectionNote: null
    }];

    var newOrder = {
      thumbnail: "./img/demo1.jpg",
      brand: "请选择",
      model: "请选择",
      province: "请选择",
      city: "请选择",
      year: "请选择",
      color: "请填写",
      innerColor: "请填写",
      orderState: "新建",
      orderNo: "FT7001254",
      carPlateDate: "请填写",
      drivingMileage: "请填写",
      cooperation: "1973",
      productionDate: "请填写",
      carPlateCity: "请填写",
      expectedPrice: "请填写",
      tradePrice: "请填写",
      modified: "无改装",
      images: [],
      VIN: "请填写",
      insuranceNo: "请填写",
      commercialRiskNo: "请填写",
      carPlateNo: "请填写",
      orderType: "普通",
      vehicleInspectionNote: null
    };

    return {
      all: function() {
        return orders;
      },
      todos: function() {
        return _.filter(orders, function(o) {
          return o.orderState === "已审核";
        });
      },
      get: function(orderNo) {
        for (var i = 0; i < orders.length; i++) {
          if (orders[i].orderNo === orderNo) {
            return orders[i];
          }
        }
        return null;
      },
      saveNewOrder: function() {
        newOrder.orderState = "已审核";
        orders.push(newOrder);
        newOrder = {
          thumbnail: "./img/demo1.jpg",
          brand: "请选择",
          model: "请选择",
          province: "请选择",
          city: "请选择",
          year: "请选择",
          color: "请填写",
          innerColor: "请填写",
          orderState: "新建",
          orderNo: "FT7001254",
          carPlateDate: "请填写",
          drivingMileage: "请填写",
          cooperation: "1973",
          productionDate: "请填写",
          carPlateCity: "请填写",
          expectedPrice: "请填写",
          tradePrice: "请填写",
          modified: "无改装",
          images: [],
          VIN: "请填写",
          insuranceNo: "请填写",
          commercialRiskNo: "请填写",
          carPlateNo: "请填写",
          orderType: "普通",
          vehicleInspectionNote: null
        };
      },
      newOrder: function()
      {
        return newOrder;
      }
    };
  });

//angular.module("cheping.services", [])
//  .factory("localStorage", ["$window", function($window) {
//    return {
//      set: function(key, value) {
//        $window.localStorage[key] = value;
//      },
//      get: function(key, defaultValue) {
//        return $window.localStorage[key] || defaultValue;
//      },
//      setObject: function(key, value) {
//        $window.localStorage[key] = JSON.stringify(value);
//      },
//      getObject: function(key, defaultValue) {
//        if ($window.localStorage[key] === undefined) {
//          return defaultValue;
//        }
//        return JSON.parse($window.localStorage[key] || '{}');
//      }
//    }
//  }])
//  .factory("OrderService", ["localStorage", function(localStorage) {
//    var orders = localStorage.getObject("orders");
//    return {
//      saveChanges: function() {
//        localStorage.setObject("orders", orders);
//      },
//      getOrders: function() {
//        return orders;
//      },
//      getOrder: function(orderNo) {
//        return _(orders).find(function(o) {
//          return o.orderNo = orderNo;
//        });
//      },
//      getTodos: function() {
//        return _(orders).select(function(o) {
//          return o.status === "已审核";
//        })
//      },
//      newOrder: function(order) {
//        orders.push(order);
//      }
//
//    }
//  }])
//  .factory("ConfigService", [function() {
//    return {
//      getCarTypes: function() {
//        return [{
//          thumbnail: "/img/demo2.jpg",
//          name: "跑车"
//        }, {
//          thumbnail: "/img/demo2.jpg",
//          name: "轿车"
//        }, {
//          thumbnail: "/img/demo2.jpg",
//          name: "越野"
//        }, {
//          thumbnail: "/img/demo2.jpg",
//          name: "房车"
//        }]
//      },
//      getCurrentUser: function() {
//        return {
//          userName: "15800780728",
//          password: "cheping1973"
//        }
//      }
//    }
//  }]);
//
////.factory('Chats', function() {
//// Might use a resource here that returns a JSON array
//
//// Some fake testing data
////   var chats = [{
////     id: 0,
////     name: 'Ben Sparrow',
////     lastText: 'You on your way?',
////     face: 'https://pbs.twimg.com/profile_images/514549811765211136/9SgAuHeY.png'
////   }, {
////     id: 1,
////     name: 'Max Lynx',
////     lastText: 'Hey, it\'s me',
////     face: 'https://avatars3.githubusercontent.com/u/11214?v=3&s=460'
////   },{
////     id: 2,
////     name: 'Adam Bradleyson',
////     lastText: 'I should buy a boat',
////     face: 'https://pbs.twimg.com/profile_images/479090794058379264/84TKj_qa.jpeg'
////   }, {
////     id: 3,
////     name: 'Perry Governor',
////     lastText: 'Look at my mukluks!',
////     face: 'https://pbs.twimg.com/profile_images/491995398135767040/ie2Z_V6e.jpeg'
////   }, {
////     id: 4,
////     name: 'Mike Harrington',
////     lastText: 'This is wicked good ice cream.',
////     face: 'https://pbs.twimg.com/profile_images/578237281384841216/R3ae1n61.png'
////   }];
//
////   return {
////     all: function() {
////       return chats;
////     },
////     remove: function(chat) {
////       chats.splice(chats.indexOf(chat), 1);
////     },
////     get: function(chatId) {
////       for (var i = 0; i < chats.length; i++) {
////         if (chats[i].id === parseInt(chatId)) {
////           return chats[i];
////         }
////       }
////       return null;
////     }
////   };
//// });
