angular.module('cheping.filters', [])
    .filter('colorName', function() {
        return function(colorId) {
            return '白色';
        };
    })
    .filter('colorCode', function() {
        return function(colorId) {
            return '#FFFFFF';
        };
    })
    .filter('city', function() {
        return function(cityId) {
            return '上海';
        };
    })
    .filter('state', function() {
        return function(stateId) {
            switch(stateId) {
                case 10:
                    return '评估中';
                case 20:
                    return '审核中';
                case 25:
                    return '审核失败';
                case 30:
                    return '验车';
                case 35:
                    return '验车失败';
                case 40:
                    return '查询';
                case 50:
                    return '报价';
                case 55:
                    return '放弃报价';
                case 60:
                    return '洽谈';
                case 65:
                    return '洽谈失败';
                case 70:
                    return '申请打款';
                case 75:
                    return '放弃打款';
                case 80:
                    return '打款审核';
                case 85:
                    return '打款审核未通过';
                case 90:
                    return '采购';
                case 95:
                    return '采购失败';
                case 100:
                    return '入库';
                default:
                    return '错误';
            }
        };
    });