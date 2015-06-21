angular.module('cheping.services', [
    'angular-cache'
])
    .service('AuthService', function(CacheService) {
        var service = this;
        var tokenStorage = CacheService.get('authTokenCache');

        service.clearToken = function() {
            tokenStorage.put('auth', '');
        };

        service.getToken = function() {
            return tokenStorage.get('auth') || '';
        };

        service.setToken = function(newToken) {
            if (newToken) {
                tokenStorage.put('auth', newToken);
            }
        };
    })
    .service('CacheService', function(CacheFactory) {
        var service = this;

        CacheFactory('authTokenCache', {
            maxAge: 24 * 60 * 60 * 1000,
            deleteOnExpire: 'aggressive',
            storageMode: 'localStorage'
        });

        CacheFactory('caseCache', {
            maxAge: 5 * 1000,
            deleteOnExpire: 'aggressive',
            storageMode: 'memory'
        });

        CacheFactory('userCache', {
            maxAge: 5 * 1000,
            deleteOnExpire: 'aggressive',
            storageMode: 'memory'
        });

        service.get = function(cacheName, maxAge) {
            maxAge = maxAge || 60 * 1000;

            if (!CacheFactory.get(cacheName)) {
                CacheFactory(cacheName, {
                    maxAge: maxAge,
                    deleteOnExpire: 'aggressive',
                    storageMode: 'localStorage'
                });
            }

            return CacheFactory.get(cacheName);
        };
    })
    .service('ConfigService', function($http, $q, URLS, CacheService) {
        var service = this;

        service.getColors = function() {
            return [{
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
        };

        service.getCooperationMethod = function() {
            return [{
                id: 10,
                name: '1973'
            }, {
                id: 20,
                name: '自销'
            }];
        };

        service.getCitis = function() {
            return [{
                name: "北京",
                items: [
                    {id: 1, city: "东城区"},
                    {id: 2, city: "西城区"},
                    {id: 3, city: "崇文区"},
                    {id: 4, city: "宣武区"},
                    {id: 5, city: "朝阳区"},
                    {id: 6, city: "丰台区"},
                    {id: 7, city: "石景山区"},
                    {id: 8, city: "海淀区"},
                    {id: 9, city: "门头沟区"},
                    {id: 10, city: "房山区"},
                    {id: 11, city: "通州区"},
                    {id: 12, city: "顺义区"},
                    {id: 13, city: "昌平区"},
                    {id: 14, city: "大兴区"},
                    {id: 15, city: "平谷区"},
                    {id: 16, city: "怀柔区"},
                    {id: 17, city: "密云县"},
                    {id: 18, city: "延庆县"}
                ]
            }, {
                name: "上海",
                items: [
                    {id: 19, city: "浦东新区"},
                    {id: 20, city: "徐汇区"},
                    {id: 21, city: "黄浦区"},
                    {id: 22, city: "杨浦区"},
                    {id: 23, city: "虹口区"},
                    {id: 24, city: "闵行区"},
                    {id: 25, city: "长宁区"},
                    {id: 26, city: "普陀区"},
                    {id: 27, city: "宝山区"},
                    {id: 28, city: "静安区"},
                    {id: 29, city: "闸北区"},
                    {id: 30, city: "卢湾区"},
                    {id: 31, city: "松江区"},
                    {id: 32, city: "嘉定区"},
                    {id: 33, city: "南汇区"},
                    {id: 34, city: "金山区"},
                    {id: 35, city: "青浦区"},
                    {id: 36, city: "奉贤区"},
                    {id: 37, city: "崇明县"}
                ]
            }, {
                name: "天津",
                items: [
                    {id: 38, city: "和平区"},
                    {id: 39, city: "河东区"},
                    {id: 40, city: "河西区"},
                    {id: 41, city: "南开区"},
                    {id: 42, city: "河北区"},
                    {id: 43, city: "红桥区"},
                    {id: 44, city: "塘沽区"},
                    {id: 45, city: "汉沽区"},
                    {id: 46, city: "大港区"},
                    {id: 47, city: "东丽区"},
                    {id: 48, city: "西青区"},
                    {id: 49, city: "津南区"},
                    {id: 50, city: "北辰区"},
                    {id: 51, city: "武清区"},
                    {id: 52, city: "宝坻区"},
                    {id: 53, city: "宁河县"},
                    {id: 54, city: "静海县"},
                    {id: 55, city: "蓟县"}
                ]
            }, {
                name: "重庆",
                items: [
                    {id: 56, city: "万州区"},
                    {id: 57, city: "涪陵区"},
                    {id: 58, city: "渝中区"},
                    {id: 59, city: "大渡口区"},
                    {id: 60, city: "江北区"},
                    {id: 61, city: "沙坪坝区"},
                    {id: 62, city: "九龙坡区"},
                    {id: 63, city: "南岸区"},
                    {id: 64, city: "北碚区"},
                    {id: 65, city: "万盛区"},
                    {id: 66, city: "双桥区"},
                    {id: 67, city: "渝北区"},
                    {id: 68, city: "巴南区"},
                    {id: 69, city: "长寿县"},
                    {id: 70, city: "綦江县"},
                    {id: 71, city: "潼南县"},
                    {id: 72, city: "铜梁县"},
                    {id: 73, city: "大足县"},
                    {id: 74, city: "荣昌县"},
                    {id: 75, city: "璧山县"},
                    {id: 76, city: "梁平县"},
                    {id: 77, city: "城口县"},
                    {id: 78, city: "丰都县"},
                    {id: 79, city: "垫江县"},
                    {id: 80, city: "武隆县"},
                    {id: 81, city: "忠县"},
                    {id: 82, city: "开县"},
                    {id: 83, city: "云阳县"},
                    {id: 84, city: "奉节县"},
                    {id: 85, city: "巫山县"},
                    {id: 86, city: "巫溪县"},
                    {id: 87, city: "黔江土家族苗族自治县"},
                    {id: 88, city: "石柱土家族自治县"},
                    {id: 89, city: "秀山土家族苗族自治县"},
                    {id: 90, city: "酉阳土家族苗族自治县"},
                    {id: 91, city: "彭水苗族土家族自治县"},
                    {id: 92, city: "江津市"},
                    {id: 93, city: "合川市"},
                    {id: 94, city: "永川市"},
                    {id: 95, city: "南川市"}
                ]
            }, {
                name: "宁夏",
                items: [
                    {id: 96, city: "银川市"},
                    {id: 97, city: "石嘴山市"},
                    {id: 98, city: "吴忠市"},
                    {id: 99, city: "固原地区"},
                    {id: 100, city: "中卫市"}
                ]
            }, {
                name: "内蒙古",
                items: [
                    {id: 101, city: "呼和浩特市"},
                    {id: 102, city: "包头市"},
                    {id: 103, city: "乌海市"},
                    {id: 104, city: "赤峰市"},
                    {id: 105, city: "呼伦贝尔市"},
                    {id: 106, city: "兴安盟"},
                    {id: 107, city: "通辽市"},
                    {id: 108, city: "锡林郭勒盟"},
                    {id: 109, city: "乌兰察布盟"},
                    {id: 110, city: "伊克昭盟"},
                    {id: 111, city: "巴彦淖尔盟"},
                    {id: 112, city: "阿拉善盟"}
                ]
            }, {
                name: "安徽省",
                items: [
                    {id: 113, city: "合肥市"},
                    {id: 114, city: "芜湖市"},
                    {id: 115, city: "蚌埠市"},
                    {id: 116, city: "淮南市"},
                    {id: 117, city: "马鞍山市"},
                    {id: 118, city: "淮北市"},
                    {id: 119, city: "铜陵市"},
                    {id: 120, city: "安庆市"},
                    {id: 121, city: "黄山市"},
                    {id: 122, city: "滁州市"},
                    {id: 123, city: "阜阳市"},
                    {id: 124, city: "宿州市"},
                    {id: 125, city: "六安市"},
                    {id: 126, city: "宣城市"},
                    {id: 127, city: "巢湖市"},
                    {id: 128, city: "池州市"}
                ]
            }, {
                name: "福建省",
                items: [
                    {id: 129, city: "福州市"},
                    {id: 130, city: "厦门市"},
                    {id: 131, city: "宁德市"},
                    {id: 132, city: "莆田市"},
                    {id: 133, city: "泉州市"},
                    {id: 134, city: "漳州市"},
                    {id: 135, city: "龙岩"},
                    {id: 136, city: "三明市"},
                    {id: 137, city: "南平市"}
                ]
            }, {
                name: "甘肃省",
                items: [
                    {id: 138, city: "兰州市"},
                    {id: 139, city: "嘉峪关市"},
                    {id: 140, city: "金昌市"},
                    {id: 141, city: "白银市"},
                    {id: 142, city: "天水市"},
                    {id: 143, city: "酒泉地区"},
                    {id: 144, city: "张掖地区"},
                    {id: 145, city: "武威地区"},
                    {id: 146, city: "定西地区"},
                    {id: 147, city: "陇南地区"},
                    {id: 148, city: "平凉地区"},
                    {id: 149, city: "庆阳地区"},
                    {id: 150, city: "临夏回族自治州"},
                    {id: 151, city: "甘南藏族自治州"}
                ]
            }, {
                name: "广东省",
                items: [
                    {id: 152, city: "广州市"},
                    {id: 153, city: "韶关市"},
                    {id: 154, city: "深圳市"},
                    {id: 155, city: "珠海市"},
                    {id: 156, city: "汕头市"},
                    {id: 157, city: "佛山市"},
                    {id: 158, city: "江门市"},
                    {id: 159, city: "湛江市"},
                    {id: 160, city: "茂名市"},
                    {id: 161, city: "肇庆市"},
                    {id: 162, city: "惠州市"},
                    {id: 163, city: "梅州市"},
                    {id: 164, city: "汕尾市"},
                    {id: 165, city: "河源市"},
                    {id: 166, city: "阳江市"},
                    {id: 167, city: "清远市"},
                    {id: 168, city: "潮州市"},
                    {id: 169, city: "揭阳市"},
                    {id: 170, city: "云浮市"},
                    {id: 171, city: "东莞市"},
                    {id: 172, city: "中山市"}
                ]
            }, {
                name: "广西省",
                items: [
                    {id: 173, city: "南宁市"},
                    {id: 174, city: "柳州市"},
                    {id: 175, city: "桂林市"},
                    {id: 176, city: "梧州市"},
                    {id: 177, city: "北海市"},
                    {id: 178, city: "防城港市"},
                    {id: 179, city: "钦州市"},
                    {id: 180, city: "贵港市"},
                    {id: 181, city: "玉林市"},
                    {id: 182, city: "崇左市"},
                    {id: 183, city: "来宾市"},
                    {id: 184, city: "贺州市"},
                    {id: 185, city: "百色市"},
                    {id: 186, city: "河池市"}
                ]
            }, {
                name: "贵州省",
                items: [
                    {id: 187, city: "贵阳市"},
                    {id: 188, city: "六盘水市"},
                    {id: 189, city: "遵义市"},
                    {id: 190, city: "铜仁地区"},
                    {id: 191, city: "黔西南布依族苗族自治州"},
                    {id: 192, city: "毕节地区"},
                    {id: 193, city: "安顺地区"},
                    {id: 194, city: "黔东南苗族侗族自治州"},
                    {id: 195, city: "黔南布依族苗族自治州"}
                ]
            }, {
                name: "海南省",
                items: [
                    {id: 196, city: "海口市"},
                    {id: 197, city: "三亚市"},
                    {id: 198, city: "文昌市"},
                    {id: 199, city: "万宁市"},
                    {id: 200, city: "东方市"},
                    {id: 201, city: "定安县"},
                    {id: 202, city: "屯昌县"},
                    {id: 203, city: "澄迈县"},
                    {id: 204, city: "临高县"},
                    {id: 205, city: "白沙黎族自治县"},
                    {id: 206, city: "昌江黎族自治县"},
                    {id: 207, city: "乐东黎族自治县"},
                    {id: 208, city: "陵水黎族自治县"},
                    {id: 209, city: "保亭黎族苗族自治县"},
                    {id: 210, city: "琼中黎族苗族自治县"},
                    {id: 211, city: "西南中沙群岛办事处"}
                ]
            }, {
                name: "河北省",
                items: [
                    {id: 212, city: "石家庄市"},
                    {id: 213, city: "唐山市"},
                    {id: 214, city: "秦皇岛市"},
                    {id: 215, city: "邯郸市"},
                    {id: 216, city: "邢台市"},
                    {id: 217, city: "保定市"},
                    {id: 218, city: "张家口市"},
                    {id: 219, city: "承德市"},
                    {id: 220, city: "沧州市"},
                    {id: 221, city: "廊坊市"},
                    {id: 222, city: "衡水市"}
                ]
            }, {
                name: "河南省",
                items: [
                    {id: 223, city: "郑州市"},
                    {id: 224, city: "开封市"},
                    {id: 225, city: "洛阳市"},
                    {id: 226, city: "平顶山市"},
                    {id: 227, city: "安阳市"},
                    {id: 228, city: "鹤壁市"},
                    {id: 229, city: "新乡市"},
                    {id: 230, city: "焦作市"},
                    {id: 231, city: "濮阳市"},
                    {id: 232, city: "许昌市"},
                    {id: 233, city: "漯河市"},
                    {id: 234, city: "三门峡市"},
                    {id: 235, city: "南阳市"},
                    {id: 236, city: "商丘市"},
                    {id: 237, city: "信阳市"},
                    {id: 238, city: "周口市"},
                    {id: 239, city: "济源市"},
                    {id: 240, city: "驻马店地区"}
                ]
            }, {
                name: "黑龙江",
                items: [
                    {id: 241, city: "哈尔滨市"},
                    {id: 242, city: "齐齐哈尔市"},
                    {id: 243, city: "鸡西市"},
                    {id: 244, city: "鹤岗市"},
                    {id: 245, city: "双鸭山市"},
                    {id: 246, city: "大庆市"},
                    {id: 247, city: "伊春市"},
                    {id: 248, city: "七台河市"},
                    {id: 249, city: "牡丹江市"},
                    {id: 250, city: "黑河市"},
                    {id: 251, city: "绥化市"},
                    {id: 252, city: "大兴安岭地区"}
                ]
            }, {
                name: "湖北省",
                items: [
                    {id: 253, city: "武汉市"},
                    {id: 254, city: "黄石市"},
                    {id: 255, city: "十堰市"},
                    {id: 256, city: "宜昌市"},
                    {id: 257, city: "襄樊市"},
                    {id: 258, city: "鄂州市"},
                    {id: 259, city: "荆门市"},
                    {id: 260, city: "孝感市"},
                    {id: 261, city: "荆州市"},
                    {id: 262, city: "黄冈市"},
                    {id: 263, city: "咸宁市"},
                    {id: 264, city: "恩施土家族苗族自治州"},
                    {id: 265, city: "仙桃市"},
                    {id: 266, city: "潜江市"},
                    {id: 267, city: "天门市"},
                    {id: 268, city: "神农架林区"}
                ]
            }, {
                name: "湖南省",
                items: [
                    {id: 269, city: "长沙市"},
                    {id: 270, city: "株洲市"},
                    {id: 271, city: "湘潭市"},
                    {id: 272, city: "衡阳市"},
                    {id: 273, city: "邵阳市"},
                    {id: 274, city: "岳阳市"},
                    {id: 275, city: "常德市"},
                    {id: 276, city: "张家界市"},
                    {id: 277, city: "益阳市"},
                    {id: 278, city: "郴州市"},
                    {id: 279, city: "永州市"},
                    {id: 280, city: "怀化市"},
                    {id: 281, city: "娄底地区"},
                    {id: 282, city: "湘西土家族苗族自治州"}
                ]
            }, {
                name: "吉林省",
                items: [
                    {id: 283, city: "长春市"},
                    {id: 284, city: "吉林市"},
                    {id: 285, city: "四平市"},
                    {id: 286, city: "辽源市"},
                    {id: 287, city: "通化市"},
                    {id: 288, city: "白山市"},
                    {id: 289, city: "松原市"},
                    {id: 290, city: "白城市"},
                    {id: 291, city: "延边朝鲜族自治州"}
                ]
            }, {
                name: "江苏省",
                items: [
                    {id: 92, city: "南京市"},
                    {id: 93, city: "无锡市"},
                    {id: 94, city: "徐州市"},
                    {id: 95, city: "常州市"},
                    {id: 96, city: "苏州市"},
                    {id: 97, city: "南通市"},
                    {id: 98, city: "连云港市"},
                    {id: 99, city: "淮阴市"},
                    {id: 100, city: "盐城市"},
                    {id: 101, city: "扬州市"},
                    {id: 102, city: "镇江市"},
                    {id: 103, city: "泰州市"},
                    {id: 304, city: "宿迁市"}
                ]
            }, {
                name: "江西省",
                items: [
                    {id: 305, city: "南昌市"},
                    {id: 306, city: "景德镇市"},
                    {id: 307, city: "萍乡市"},
                    {id: 308, city: "九江市"},
                    {id: 309, city: "新余市"},
                    {id: 310, city: "鹰潭市"},
                    {id: 311, city: "赣州市"},
                    {id: 312, city: "宜春市"},
                    {id: 313, city: "上饶市"},
                    {id: 314, city: "吉安市"},
                    {id: 315, city: "抚州市"}
                ]
            }, {
                name: "辽宁省",
                items: [
                    {id: 16, city: "大连市"},
                    {id: 17, city: "鞍山市"},
                    {id: 18, city: "抚顺市"},
                    {id: 19, city: "本溪市"},
                    {id: 20, city: "丹东市"},
                    {id: 21, city: "锦州市"},
                    {id: 22, city: "营口市"},
                    {id: 23, city: "阜新市"},
                    {id: 24, city: "辽阳市"},
                    {id: 25, city: "盘锦市"},
                    {id: 26, city: "铁岭市"},
                    {id: 27, city: "朝阳市"},
                    {id: 28, city: "葫芦岛市"}
                ]
            }, {
                name: "青海省",
                items: [
                    {id: 329, city: "西宁市"},
                    {id: 330, city: "海东地区"},
                    {id: 331, city: "海北藏族自治州"},
                    {id: 332, city: "黄南藏族自治州"},
                    {id: 333, city: "海南藏族自治州"},
                    {id: 334, city: "果洛藏族自治州"},
                    {id: 335, city: "玉树藏族自治州"},
                    {id: 336, city: "海西蒙古族藏族自治州"}
                ]
            }, {
                name: "山东省",
                items: [
                    {id: 337, city: "济南市"},
                    {id: 338, city: "青岛市"},
                    {id: 339, city: "淄博市"},
                    {id: 340, city: "枣庄市"},
                    {id: 341, city: "东营市"},
                    {id: 342, city: "烟台市"},
                    {id: 343, city: "潍坊市"},
                    {id: 344, city: "济宁市"},
                    {id: 345, city: "泰安市"},
                    {id: 346, city: "威海市"},
                    {id: 347, city: "日照市"},
                    {id: 348, city: "莱芜市"},
                    {id: 349, city: "临沂市"},
                    {id: 350, city: "德州市"},
                    {id: 351, city: "聊城市"},
                    {id: 352, city: "滨州市"},
                    {id: 353, city: "菏泽市"}
                ]
            }, {
                name: "山西省",
                items: [
                    {id: 354, city: "太原市"},
                    {id: 355, city: "大同市"},
                    {id: 356, city: "阳泉市"},
                    {id: 357, city: "长治市"},
                    {id: 358, city: "晋城市"},
                    {id: 359, city: "朔州市"},
                    {id: 360, city: "忻州市"},
                    {id: 361, city: "吕梁市"},
                    {id: 362, city: "晋中市"},
                    {id: 363, city: "临汾市"},
                    {id: 364, city: "运城市"}
                ]
            }, {
                name: "陕西省",
                items: [
                    {id: 365, city: "西安市"},
                    {id: 366, city: "铜川市"},
                    {id: 367, city: "宝鸡市"},
                    {id: 368, city: "咸阳市"},
                    {id: 369, city: "渭南市"},
                    {id: 370, city: "延安市"},
                    {id: 371, city: "汉中市"},
                    {id: 372, city: "安康地区"},
                    {id: 373, city: "商洛地区"},
                    {id: 374, city: "榆林地区"}
                ]
            }, {
                name: "四川省",
                items: [
                    {id: 375, city: "成都市"},
                    {id: 376, city: "自贡市"},
                    {id: 377, city: "攀枝花市"},
                    {id: 378, city: "泸州市"},
                    {id: 379, city: "德阳市"},
                    {id: 380, city: "绵阳市"},
                    {id: 381, city: "广元市"},
                    {id: 382, city: "遂宁市"},
                    {id: 383, city: "内江市"},
                    {id: 384, city: "乐山市"},
                    {id: 385, city: "南充市"},
                    {id: 386, city: "宜宾市"},
                    {id: 387, city: "广安市"},
                    {id: 388, city: "达川地区"},
                    {id: 389, city: "雅安地区"},
                    {id: 390, city: "阿坝藏族羌族自治州"},
                    {id: 391, city: "甘孜藏族自治州"},
                    {id: 392, city: "凉山彝族自治州"},
                    {id: 393, city: "巴中地区"},
                    {id: 394, city: "眉山地区"},
                    {id: 395, city: "资阳地区"}
                ]
            }, {
                name: "云南省",
                items: [
                    {id: 396, city: "昆明市"},
                    {id: 397, city: "曲靖市"},
                    {id: 398, city: "玉溪市"},
                    {id: 399, city: "昭通地区"},
                    {id: 400, city: "楚雄彝族自治州"},
                    {id: 401, city: "红河哈尼族彝族自治州"},
                    {id: 402, city: "文山壮族苗族自治州"},
                    {id: 403, city: "思茅市"},
                    {id: 404, city: "西双版纳傣族自治州"},
                    {id: 405, city: "大理白族自治州"},
                    {id: 406, city: "保山地区"},
                    {id: 407, city: "德宏傣族景颇族自治州"},
                    {id: 408, city: "丽江地区"},
                    {id: 409, city: "怒江傈僳族自治州"},
                    {id: 410, city: "迪庆藏族自治州"},
                    {id: 411, city: "临沧地区"}
                ]
            }, {
                name: "浙江省",
                items: [
                    {id: 412, city: "杭州市"},
                    {id: 413, city: "宁波市"},
                    {id: 414, city: "温州市"},
                    {id: 415, city: "嘉兴市"},
                    {id: 416, city: "湖州市"},
                    {id: 417, city: "绍兴市"},
                    {id: 418, city: "金华市"},
                    {id: 419, city: "衢州市"},
                    {id: 420, city: "舟山市"},
                    {id: 421, city: "台州市"},
                    {id: 422, city: "丽水市"}
                ]
            }, {
                name: "西藏",
                items: [
                    {id: 423, city: "拉萨市"},
                    {id: 424, city: "昌都地区"},
                    {id: 425, city: "山南地区"},
                    {id: 426, city: "日喀则地区"},
                    {id: 427, city: "那曲地区"},
                    {id: 428, city: "阿里地区"},
                    {id: 429, city: "林芝地区"}
                ]
            }, {
                name: "新疆",
                items: [
                    {id: 430, city: "乌鲁木齐市"},
                    {id: 431, city: "克拉玛依市"},
                    {id: 432, city: "吐鲁番地区"},
                    {id: 433, city: "哈密地区"},
                    {id: 434, city: "昌吉回族自治州"},
                    {id: 435, city: "博尔塔拉蒙古自治州"},
                    {id: 436, city: "巴音郭楞蒙古自治州"},
                    {id: 437, city: "阿克苏地区"},
                    {id: 438, city: "克孜勒苏柯尔克孜自治州"},
                    {id: 439, city: "喀什地区"},
                    {id: 440, city: "和田地区"},
                    {id: 441, city: "伊犁哈萨克自治州"},
                    {id: 442, city: "塔城地区"},
                    {id: 443, city: "阿勒泰地区"},
                    {id: 444, city: "石河子市"},
                    {id: 445, city: "阿拉尔市"},
                    {id: 446, city: "图木舒克市"},
                    {id: 447, city: "五家渠市"}
                ]
            }
            ];
        };

    })
    .service('UtilityService', function($state, $ionicPopup, $timeout, $cordovaInAppBrowser) {
        var service = this;

        /**
         * Matcher.
         */

        var matcher = /^(?:\w+:)?\/\/([^\s\.]+\.\S{2}|localhost[:?\d]*)\S*$/;

        /**
         * Loosely validate a URL `string`.
         *
         * @param {String} string
         * @return {Boolean}
         */

        function isUrl(string) {
            return matcher.test(string);
        }

        function open(url) {
            if (service.isUrl(url)) {
                $cordovaInAppBrowser.open(url, '_system');
            } else {
                $state.go(url);
            }
        }

        function showAlert(text) {
            var alertPopup = $ionicPopup.alert({
                title: '提示信息',
                template: text
            });

            $timeout(function() {
                alertPopup.close();
            }, 2000);
        }

        service.isUrl = isUrl;
        service.open = open;
        service.showAlert = showAlert;
    });