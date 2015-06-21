angular.module('cheping.filters', [])
    .filter('colorName', function() {
        return function(colorId) {
            if(!isFinite(colorId)) {
                return colorId;
            }

            var colors = [{
                colorId: 1,
                colorName: '银灰色',
                colorCode: '#c0c0c0'
            }, {
                colorId: 2,
                colorName: '浅灰色',
                colorCode: '#d3d3d3'
            }, {
                colorId: 3,
                colorName: '白色',
                colorCode: '#c0c0c0'
            }, {
                colorId: 4,
                colorName: '象牙白色',
                colorCode: '#fafff0'
            }, {
                colorId: 5,
                colorName: '黑色',
                colorCode: '#000000'
            }, {
                colorId: 6,
                colorName: '红色',
                colorCode: '#ff0000'
            }, {
                colorId: 7,
                colorName: '深红色',
                colorCode: '#cc0000'
            }, {
                colorId: 8,
                colorName: '粉红色',
                colorCode: '#ff33ff'
            }, {
                colorId: 9,
                colorName: '赭石红色',
                colorCode: '#660033'
            }, {
                colorId: 10,
                colorName: '蓝色',
                colorCode: '#0000ff'
            }, {
                colorId: 11,
                colorName: '天蓝色',
                colorCode: '#87ceeb'
            }, {
                colorId: 12,
                colorName: '深蓝色',
                colorCode: '#0000cc'
            }, {
                colorId: 13,
                colorName: '天蓝色',
                colorCode: '#87ceeb'
            }, {
                colorId: 14,
                colorName: '深蓝色',
                colorCode: '#0000cc'
            }, {
                colorId: 15,
                colorName: '黄色',
                colorCode: '#ffff00'
            }, {
                colorId: 16,
                colorName: '金黄色',
                colorCode: '#ffcc00'
            }, {
                colorId: 17,
                colorName: '沙漠黄色',
                colorCode: '#cccc00'
            }, {
                colorId: 18,
                colorName: '绿色',
                colorCode: '#00ff00'
            }, {
                colorId: 19,
                colorName: '浅绿色',
                colorCode: '#66ff00'
            }, {
                colorId: 20,
                colorName: '嫩绿色',
                colorCode: '#33ff00'
            }, {
                colorId: 21,
                colorName: '墨绿色',
                colorCode: '#006600'
            }, {
                colorId: 22,
                colorName: '橙色',
                colorCode: '#ff9900'
            }
            ];

            var color = _.find(colors, function(c) {
                return c.colorId === colorId;
            });

            if(color) {
                return color.colorName;
            }else{
                return '白色';
            }
        };
    })
    .filter('colorCode', function() {
        return function(colorId) {
            if(!isFinite(colorId)) {
                return colorId;
            }

            var colors = [{
                colorId: 1,
                colorName: '银灰色',
                colorCode: '#c0c0c0'
            }, {
                colorId: 2,
                colorName: '浅灰色',
                colorCode: '#d3d3d3'
            }, {
                colorId: 3,
                colorName: '白色',
                colorCode: '#c0c0c0'
            }, {
                colorId: 4,
                colorName: '象牙白色',
                colorCode: '#fafff0'
            }, {
                colorId: 5,
                colorName: '黑色',
                colorCode: '#000000'
            }, {
                colorId: 6,
                colorName: '红色',
                colorCode: '#ff0000'
            }, {
                colorId: 7,
                colorName: '深红色',
                colorCode: '#cc0000'
            }, {
                colorId: 8,
                colorName: '粉红色',
                colorCode: '#ff33ff'
            }, {
                colorId: 9,
                colorName: '赭石红色',
                colorCode: '#660033'
            }, {
                colorId: 10,
                colorName: '蓝色',
                colorCode: '#0000ff'
            }, {
                colorId: 11,
                colorName: '天蓝色',
                colorCode: '#87ceeb'
            }, {
                colorId: 12,
                colorName: '深蓝色',
                colorCode: '#0000cc'
            }, {
                colorId: 13,
                colorName: '天蓝色',
                colorCode: '#87ceeb'
            }, {
                colorId: 14,
                colorName: '深蓝色',
                colorCode: '#0000cc'
            }, {
                colorId: 15,
                colorName: '黄色',
                colorCode: '#ffff00'
            }, {
                colorId: 16,
                colorName: '金黄色',
                colorCode: '#ffcc00'
            }, {
                colorId: 17,
                colorName: '沙漠黄色',
                colorCode: '#cccc00'
            }, {
                colorId: 18,
                colorName: '绿色',
                colorCode: '#00ff00'
            }, {
                colorId: 19,
                colorName: '浅绿色',
                colorCode: '#66ff00'
            }, {
                colorId: 20,
                colorName: '嫩绿色',
                colorCode: '#33ff00'
            }, {
                colorId: 21,
                colorName: '墨绿色',
                colorCode: '#006600'
            }, {
                colorId: 22,
                colorName: '橙色',
                colorCode: '#ff9900'
            }
            ];

            var color = _.find(colors, function(c) {
                return c.colorId === colorId;
            });

            if(color) {
                return color.colorCode;
            }else{
                return '#FFFFFF';
            }
        };
    })
    .filter('city', function() {
        return function(cityId) {
            if(!isFinite(cityId)) {
                return cityId;
            }

            return '上海';
        };
    })
    .filter('cooperationMethod', function() {
        return function(cooperationMethodId) {
            if(!isFinite(cooperationMethodId)) {
                return cooperationMethodId;
            }

            switch(cooperationMethodId) {
                case 10:
                    return '1973';
                case 20:
                    return '自营';
                default:
                    return '1973';
            }
        };
    })
    .filter('time', function() {
        return function(time) {
            if(!isFinite(time)) {
                return time;
            }

            return moment(time).format('LL');
        };
    })
    .filter('state', function() {
        return function(stateId) {
            if(!isFinite(stateId)) {
                return stateId;
            }

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