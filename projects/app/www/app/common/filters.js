angular.module('cheping.filters', [])
    .filter('colorName', function() {
        return function(colorId) {
            if (!isFinite(colorId)) {
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

            if (color) {
                return color.colorName;
            } else {
                return '白色';
            }
        };
    })
    .filter('colorCode', function() {
        return function(colorId) {
            if (!isFinite(colorId)) {
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

            if (color) {
                return color.colorCode;
            } else {
                return '#FFFFFF';
            }
        };
    })
    .filter('city', function() {
        return function(cityId) {
            if (!isFinite(cityId)) {
                return cityId;
            }

            var citis = [
                {id: 1, cityName: '北京  东城区'},
                {id: 2, cityName: '北京  西城区'},
                {id: 3, cityName: '北京  崇文区'},
                {id: 4, cityName: '北京  宣武区'},
                {id: 5, cityName: '北京  朝阳区'},
                {id: 6, cityName: '北京  丰台区'},
                {id: 7, cityName: '北京  石景山区'},
                {id: 8, cityName: '北京  海淀区'},
                {id: 9, cityName: '北京  门头沟区'},
                {id: 10, cityName: '北京  房山区'},
                {id: 11, cityName: '北京  通州区'},
                {id: 12, cityName: '北京  顺义区'},
                {id: 13, cityName: '北京  昌平区'},
                {id: 14, cityName: '北京  大兴区'},
                {id: 15, cityName: '北京  平谷区'},
                {id: 16, cityName: '北京  怀柔区'},
                {id: 17, cityName: '北京  密云县'},
                {id: 18, cityName: '北京  延庆县'},
                {id: 19, cityName: '上海  浦东新区'},
                {id: 20, cityName: '上海  徐汇区'},
                {id: 21, cityName: '上海  黄浦区'},
                {id: 22, cityName: '上海  杨浦区'},
                {id: 23, cityName: '上海  虹口区'},
                {id: 24, cityName: '上海  闵行区'},
                {id: 25, cityName: '上海  长宁区'},
                {id: 26, cityName: '上海  普陀区'},
                {id: 27, cityName: '上海  宝山区'},
                {id: 28, cityName: '上海  静安区'},
                {id: 29, cityName: '上海  闸北区'},
                {id: 30, cityName: '上海  卢湾区'},
                {id: 31, cityName: '上海  松江区'},
                {id: 32, cityName: '上海  嘉定区'},
                {id: 33, cityName: '上海  南汇区'},
                {id: 34, cityName: '上海  金山区'},
                {id: 35, cityName: '上海  青浦区'},
                {id: 36, cityName: '上海  奉贤区'},
                {id: 37, cityName: '上海  崇明县'},
                {id: 38, cityName: '天津  和平区'},
                {id: 39, cityName: '天津  河东区'},
                {id: 40, cityName: '天津  河西区'},
                {id: 41, cityName: '天津  南开区'},
                {id: 42, cityName: '天津  河北区'},
                {id: 43, cityName: '天津  红桥区'},
                {id: 44, cityName: '天津  塘沽区'},
                {id: 45, cityName: '天津  汉沽区'},
                {id: 46, cityName: '天津  大港区'},
                {id: 47, cityName: '天津  东丽区'},
                {id: 48, cityName: '天津  西青区'},
                {id: 49, cityName: '天津  津南区'},
                {id: 50, cityName: '天津  北辰区'},
                {id: 51, cityName: '天津  武清区'},
                {id: 52, cityName: '天津  宝坻区'},
                {id: 53, cityName: '天津  宁河县'},
                {id: 54, cityName: '天津  静海县'},
                {id: 55, cityName: '天津  蓟县'},
                {id: 56, cityName: '重庆  万州区'},
                {id: 57, cityName: '重庆  涪陵区'},
                {id: 58, cityName: '重庆  渝中区'},
                {id: 59, cityName: '重庆  大渡口区'},
                {id: 60, cityName: '重庆  江北区'},
                {id: 61, cityName: '重庆  沙坪坝区'},
                {id: 62, cityName: '重庆  九龙坡区'},
                {id: 63, cityName: '重庆  南岸区'},
                {id: 64, cityName: '重庆  北碚区'},
                {id: 65, cityName: '重庆  万盛区'},
                {id: 66, cityName: '重庆  双桥区'},
                {id: 67, cityName: '重庆  渝北区'},
                {id: 68, cityName: '重庆  巴南区'},
                {id: 69, cityName: '重庆  长寿县'},
                {id: 70, cityName: '重庆  綦江县'},
                {id: 71, cityName: '重庆  潼南县'},
                {id: 72, cityName: '重庆  铜梁县'},
                {id: 73, cityName: '重庆  大足县'},
                {id: 74, cityName: '重庆  荣昌县'},
                {id: 75, cityName: '重庆  璧山县'},
                {id: 76, cityName: '重庆  梁平县'},
                {id: 77, cityName: '重庆  城口县'},
                {id: 78, cityName: '重庆  丰都县'},
                {id: 79, cityName: '重庆  垫江县'},
                {id: 80, cityName: '重庆  武隆县'},
                {id: 81, cityName: '重庆  忠县'},
                {id: 82, cityName: '重庆  开县'},
                {id: 83, cityName: '重庆  云阳县'},
                {id: 84, cityName: '重庆  奉节县'},
                {id: 85, cityName: '重庆  巫山县'},
                {id: 86, cityName: '重庆  巫溪县'},
                {id: 87, cityName: '重庆  黔江土家族苗族自治县'},
                {id: 88, cityName: '重庆  石柱土家族自治县'},
                {id: 89, cityName: '重庆  秀山土家族苗族自治县'},
                {id: 90, cityName: '重庆  酉阳土家族苗族自治县'},
                {id: 91, cityName: '重庆  彭水苗族土家族自治县'},
                {id: 92, cityName: '重庆  江津市'},
                {id: 93, cityName: '重庆  合川市'},
                {id: 94, cityName: '重庆  永川市'},
                {id: 95, cityName: '重庆  南川市'},
                {id: 96, cityName: '宁夏  银川市'},
                {id: 97, cityName: '宁夏  石嘴山市'},
                {id: 98, cityName: '宁夏  吴忠市'},
                {id: 99, cityName: '宁夏  固原地区'},
                {id: 100, cityName: '宁夏  中卫市'},
                {id: 101, cityName: '内蒙古 呼和浩特市'},
                {id: 102, cityName: '内蒙古 包头市'},
                {id: 103, cityName: '内蒙古 乌海市'},
                {id: 104, cityName: '内蒙古 赤峰市'},
                {id: 105, cityName: '内蒙古 呼伦贝尔市'},
                {id: 106, cityName: '内蒙古 兴安盟'},
                {id: 107, cityName: '内蒙古 通辽市'},
                {id: 108, cityName: '内蒙古 锡林郭勒盟'},
                {id: 109, cityName: '内蒙古 乌兰察布盟'},
                {id: 110, cityName: '内蒙古 伊克昭盟'},
                {id: 111, cityName: '内蒙古 巴彦淖尔盟'},
                {id: 112, cityName: '内蒙古 阿拉善盟'},
                {id: 113, cityName: '安徽省 合肥市'},
                {id: 114, cityName: '安徽省 芜湖市'},
                {id: 115, cityName: '安徽省 蚌埠市'},
                {id: 116, cityName: '安徽省 淮南市'},
                {id: 117, cityName: '安徽省 马鞍山市'},
                {id: 118, cityName: '安徽省 淮北市'},
                {id: 119, cityName: '安徽省 铜陵市'},
                {id: 120, cityName: '安徽省 安庆市'},
                {id: 121, cityName: '安徽省 黄山市'},
                {id: 122, cityName: '安徽省 滁州市'},
                {id: 123, cityName: '安徽省 阜阳市'},
                {id: 124, cityName: '安徽省 宿州市'},
                {id: 125, cityName: '安徽省 六安市'},
                {id: 126, cityName: '安徽省 宣城市'},
                {id: 127, cityName: '安徽省 巢湖市'},
                {id: 128, cityName: '安徽省 池州市'},
                {id: 129, cityName: '福建省 福州市'},
                {id: 130, cityName: '福建省 厦门市'},
                {id: 131, cityName: '福建省 宁德市'},
                {id: 132, cityName: '福建省 莆田市'},
                {id: 133, cityName: '福建省 泉州市'},
                {id: 134, cityName: '福建省 漳州市'},
                {id: 135, cityName: '福建省 龙岩'},
                {id: 136, cityName: '福建省 三明市'},
                {id: 137, cityName: '福建省 南平市'},
                {id: 138, cityName: '甘肃省 兰州市'},
                {id: 139, cityName: '甘肃省 嘉峪关市'},
                {id: 140, cityName: '甘肃省 金昌市'},
                {id: 141, cityName: '甘肃省 白银市'},
                {id: 142, cityName: '甘肃省 天水市'},
                {id: 143, cityName: '甘肃省 酒泉地区'},
                {id: 144, cityName: '甘肃省 张掖地区'},
                {id: 145, cityName: '甘肃省 武威地区'},
                {id: 146, cityName: '甘肃省 定西地区'},
                {id: 147, cityName: '甘肃省 陇南地区'},
                {id: 148, cityName: '甘肃省 平凉地区'},
                {id: 149, cityName: '甘肃省 庆阳地区'},
                {id: 150, cityName: '甘肃省 临夏回族自治州'},
                {id: 151, cityName: '甘肃省 甘南藏族自治州'},
                {id: 152, cityName: '广东省 广州市'},
                {id: 153, cityName: '广东省 韶关市'},
                {id: 154, cityName: '广东省 深圳市'},
                {id: 155, cityName: '广东省 珠海市'},
                {id: 156, cityName: '广东省 汕头市'},
                {id: 157, cityName: '广东省 佛山市'},
                {id: 158, cityName: '广东省 江门市'},
                {id: 159, cityName: '广东省 湛江市'},
                {id: 160, cityName: '广东省 茂名市'},
                {id: 161, cityName: '广东省 肇庆市'},
                {id: 162, cityName: '广东省 惠州市'},
                {id: 163, cityName: '广东省 梅州市'},
                {id: 164, cityName: '广东省 汕尾市'},
                {id: 165, cityName: '广东省 河源市'},
                {id: 166, cityName: '广东省 阳江市'},
                {id: 167, cityName: '广东省 清远市'},
                {id: 168, cityName: '广东省 潮州市'},
                {id: 169, cityName: '广东省 揭阳市'},
                {id: 170, cityName: '广东省 云浮市'},
                {id: 171, cityName: '广东省 东莞市'},
                {id: 172, cityName: '广东省 中山市'},
                {id: 173, cityName: '广西省 南宁市'},
                {id: 174, cityName: '广西省 柳州市'},
                {id: 175, cityName: '广西省 桂林市'},
                {id: 176, cityName: '广西省 梧州市'},
                {id: 177, cityName: '广西省 北海市'},
                {id: 178, cityName: '广西省 防城港市'},
                {id: 179, cityName: '广西省 钦州市'},
                {id: 180, cityName: '广西省 贵港市'},
                {id: 181, cityName: '广西省 玉林市'},
                {id: 182, cityName: '广西省 崇左市'},
                {id: 183, cityName: '广西省 来宾市'},
                {id: 184, cityName: '广西省 贺州市'},
                {id: 185, cityName: '广西省 百色市'},
                {id: 186, cityName: '广西省 河池市'},
                {id: 187, cityName: '贵州省 贵阳市'},
                {id: 188, cityName: '贵州省 六盘水市'},
                {id: 189, cityName: '贵州省 遵义市'},
                {id: 190, cityName: '贵州省 铜仁地区'},
                {id: 191, cityName: '贵州省 黔西南布依族苗族自治州'},
                {id: 192, cityName: '贵州省 毕节地区'},
                {id: 193, cityName: '贵州省 安顺地区'},
                {id: 194, cityName: '贵州省 黔东南苗族侗族自治州'},
                {id: 195, cityName: '贵州省 黔南布依族苗族自治州'},
                {id: 196, cityName: '海南省 海口市'},
                {id: 197, cityName: '海南省 三亚市'},
                {id: 198, cityName: '海南省 文昌市'},
                {id: 199, cityName: '海南省 万宁市'},
                {id: 200, cityName: '海南省 东方市'},
                {id: 201, cityName: '海南省 定安县'},
                {id: 202, cityName: '海南省 屯昌县'},
                {id: 203, cityName: '海南省 澄迈县'},
                {id: 204, cityName: '海南省 临高县'},
                {id: 205, cityName: '海南省 白沙黎族自治县'},
                {id: 206, cityName: '海南省 昌江黎族自治县'},
                {id: 207, cityName: '海南省 乐东黎族自治县'},
                {id: 208, cityName: '海南省 陵水黎族自治县'},
                {id: 209, cityName: '海南省 保亭黎族苗族自治县'},
                {id: 210, cityName: '海南省 琼中黎族苗族自治县'},
                {id: 211, cityName: '海南省 西南中沙群岛办事处'},
                {id: 212, cityName: '河北省 石家庄市'},
                {id: 213, cityName: '河北省 唐山市'},
                {id: 214, cityName: '河北省 秦皇岛市'},
                {id: 215, cityName: '河北省 邯郸市'},
                {id: 216, cityName: '河北省 邢台市'},
                {id: 217, cityName: '河北省 保定市'},
                {id: 218, cityName: '河北省 张家口市'},
                {id: 219, cityName: '河北省 承德市'},
                {id: 220, cityName: '河北省 沧州市'},
                {id: 221, cityName: '河北省 廊坊市'},
                {id: 222, cityName: '河北省 衡水市'},
                {id: 223, cityName: '河南省 郑州市'},
                {id: 224, cityName: '河南省 开封市'},
                {id: 225, cityName: '河南省 洛阳市'},
                {id: 226, cityName: '河南省 平顶山市'},
                {id: 227, cityName: '河南省 安阳市'},
                {id: 228, cityName: '河南省 鹤壁市'},
                {id: 229, cityName: '河南省 新乡市'},
                {id: 230, cityName: '河南省 焦作市'},
                {id: 231, cityName: '河南省 濮阳市'},
                {id: 232, cityName: '河南省 许昌市'},
                {id: 233, cityName: '河南省 漯河市'},
                {id: 234, cityName: '河南省 三门峡市'},
                {id: 235, cityName: '河南省 南阳市'},
                {id: 236, cityName: '河南省 商丘市'},
                {id: 237, cityName: '河南省 信阳市'},
                {id: 238, cityName: '河南省 周口市'},
                {id: 239, cityName: '河南省 济源市'},
                {id: 240, cityName: '河南省 驻马店地区'},
                {id: 241, cityName: '黑龙江 哈尔滨市'},
                {id: 242, cityName: '黑龙江 齐齐哈尔市'},
                {id: 243, cityName: '黑龙江 鸡西市'},
                {id: 244, cityName: '黑龙江 鹤岗市'},
                {id: 245, cityName: '黑龙江 双鸭山市'},
                {id: 246, cityName: '黑龙江 大庆市'},
                {id: 247, cityName: '黑龙江 伊春市'},
                {id: 248, cityName: '黑龙江 七台河市'},
                {id: 249, cityName: '黑龙江 牡丹江市'},
                {id: 250, cityName: '黑龙江 黑河市'},
                {id: 251, cityName: '黑龙江 绥化市'},
                {id: 252, cityName: '黑龙江 大兴安岭地区'},
                {id: 253, cityName: '湖北省 武汉市'},
                {id: 254, cityName: '湖北省 黄石市'},
                {id: 255, cityName: '湖北省 十堰市'},
                {id: 256, cityName: '湖北省 宜昌市'},
                {id: 257, cityName: '湖北省 襄樊市'},
                {id: 258, cityName: '湖北省 鄂州市'},
                {id: 259, cityName: '湖北省 荆门市'},
                {id: 260, cityName: '湖北省 孝感市'},
                {id: 261, cityName: '湖北省 荆州市'},
                {id: 262, cityName: '湖北省 黄冈市'},
                {id: 263, cityName: '湖北省 咸宁市'},
                {id: 264, cityName: '湖北省 恩施土家族苗族自治州'},
                {id: 265, cityName: '湖北省 仙桃市'},
                {id: 266, cityName: '湖北省 潜江市'},
                {id: 267, cityName: '湖北省 天门市'},
                {id: 268, cityName: '湖北省 神农架林区'},
                {id: 269, cityName: '湖南省 长沙市'},
                {id: 270, cityName: '湖南省 株洲市'},
                {id: 271, cityName: '湖南省 湘潭市'},
                {id: 272, cityName: '湖南省 衡阳市'},
                {id: 273, cityName: '湖南省 邵阳市'},
                {id: 274, cityName: '湖南省 岳阳市'},
                {id: 275, cityName: '湖南省 常德市'},
                {id: 276, cityName: '湖南省 张家界市'},
                {id: 277, cityName: '湖南省 益阳市'},
                {id: 278, cityName: '湖南省 郴州市'},
                {id: 279, cityName: '湖南省 永州市'},
                {id: 280, cityName: '湖南省 怀化市'},
                {id: 281, cityName: '湖南省 娄底地区'},
                {id: 282, cityName: '湖南省 湘西土家族苗族自治州'},
                {id: 283, cityName: '吉林省 长春市'},
                {id: 284, cityName: '吉林省 吉林市'},
                {id: 285, cityName: '吉林省 四平市'},
                {id: 286, cityName: '吉林省 辽源市'},
                {id: 287, cityName: '吉林省 通化市'},
                {id: 288, cityName: '吉林省 白山市'},
                {id: 289, cityName: '吉林省 松原市'},
                {id: 290, cityName: '吉林省 白城市'},
                {id: 291, cityName: '吉林省 延边朝鲜族自治州'},
                {id: 292, cityName: '江苏省 南京市'},
                {id: 293, cityName: '江苏省 无锡市'},
                {id: 294, cityName: '江苏省 徐州市'},
                {id: 295, cityName: '江苏省 常州市'},
                {id: 296, cityName: '江苏省 苏州市'},
                {id: 297, cityName: '江苏省 南通市'},
                {id: 298, cityName: '江苏省 连云港市'},
                {id: 299, cityName: '江苏省 淮阴市'},
                {id: 300, cityName: '江苏省 盐城市'},
                {id: 301, cityName: '江苏省 扬州市'},
                {id: 302, cityName: '江苏省 镇江市'},
                {id: 303, cityName: '江苏省 泰州市'},
                {id: 304, cityName: '江苏省 宿迁市'},
                {id: 305, cityName: '江西省 南昌市'},
                {id: 306, cityName: '江西省 景德镇市'},
                {id: 307, cityName: '江西省 萍乡市'},
                {id: 308, cityName: '江西省 九江市'},
                {id: 309, cityName: '江西省 新余市'},
                {id: 310, cityName: '江西省 鹰潭市'},
                {id: 311, cityName: '江西省 赣州市'},
                {id: 312, cityName: '江西省 宜春市'},
                {id: 313, cityName: '江西省 上饶市'},
                {id: 314, cityName: '江西省 吉安市'},
                {id: 315, cityName: '江西省 抚州市'},
                {id: 316, cityName: '辽宁省 大连市'},
                {id: 317, cityName: '辽宁省 鞍山市'},
                {id: 318, cityName: '辽宁省 抚顺市'},
                {id: 319, cityName: '辽宁省 本溪市'},
                {id: 320, cityName: '辽宁省 丹东市'},
                {id: 321, cityName: '辽宁省 锦州市'},
                {id: 322, cityName: '辽宁省 营口市'},
                {id: 323, cityName: '辽宁省 阜新市'},
                {id: 324, cityName: '辽宁省 辽阳市'},
                {id: 325, cityName: '辽宁省 盘锦市'},
                {id: 326, cityName: '辽宁省 铁岭市'},
                {id: 327, cityName: '辽宁省 朝阳市'},
                {id: 328, cityName: '辽宁省 葫芦岛市'},
                {id: 329, cityName: '青海省 西宁市'},
                {id: 330, cityName: '青海省 海东地区'},
                {id: 331, cityName: '青海省 海北藏族自治州'},
                {id: 332, cityName: '青海省 黄南藏族自治州'},
                {id: 333, cityName: '青海省 海南藏族自治州'},
                {id: 334, cityName: '青海省 果洛藏族自治州'},
                {id: 335, cityName: '青海省 玉树藏族自治州'},
                {id: 336, cityName: '青海省 海西蒙古族藏族自治州'},
                {id: 337, cityName: '山东省 济南市'},
                {id: 338, cityName: '山东省 青岛市'},
                {id: 339, cityName: '山东省 淄博市'},
                {id: 340, cityName: '山东省 枣庄市'},
                {id: 341, cityName: '山东省 东营市'},
                {id: 342, cityName: '山东省 烟台市'},
                {id: 343, cityName: '山东省 潍坊市'},
                {id: 344, cityName: '山东省 济宁市'},
                {id: 345, cityName: '山东省 泰安市'},
                {id: 346, cityName: '山东省 威海市'},
                {id: 347, cityName: '山东省 日照市'},
                {id: 348, cityName: '山东省 莱芜市'},
                {id: 349, cityName: '山东省 临沂市'},
                {id: 350, cityName: '山东省 德州市'},
                {id: 351, cityName: '山东省 聊城市'},
                {id: 352, cityName: '山东省 滨州市'},
                {id: 353, cityName: '山东省 菏泽市'},
                {id: 354, cityName: '山西省 太原市'},
                {id: 355, cityName: '山西省 大同市'},
                {id: 356, cityName: '山西省 阳泉市'},
                {id: 357, cityName: '山西省 长治市'},
                {id: 358, cityName: '山西省 晋城市'},
                {id: 359, cityName: '山西省 朔州市'},
                {id: 360, cityName: '山西省 忻州市'},
                {id: 361, cityName: '山西省 吕梁市'},
                {id: 362, cityName: '山西省 晋中市'},
                {id: 363, cityName: '山西省 临汾市'},
                {id: 364, cityName: '山西省 运城市'},
                {id: 365, cityName: '陕西省 西安市'},
                {id: 366, cityName: '陕西省 铜川市'},
                {id: 367, cityName: '陕西省 宝鸡市'},
                {id: 368, cityName: '陕西省 咸阳市'},
                {id: 369, cityName: '陕西省 渭南市'},
                {id: 370, cityName: '陕西省 延安市'},
                {id: 371, cityName: '陕西省 汉中市'},
                {id: 372, cityName: '陕西省 安康地区'},
                {id: 373, cityName: '陕西省 商洛地区'},
                {id: 374, cityName: '陕西省 榆林地区'},
                {id: 375, cityName: '四川省 成都市'},
                {id: 376, cityName: '四川省 自贡市'},
                {id: 377, cityName: '四川省 攀枝花市'},
                {id: 378, cityName: '四川省 泸州市'},
                {id: 379, cityName: '四川省 德阳市'},
                {id: 380, cityName: '四川省 绵阳市'},
                {id: 381, cityName: '四川省 广元市'},
                {id: 382, cityName: '四川省 遂宁市'},
                {id: 383, cityName: '四川省 内江市'},
                {id: 384, cityName: '四川省 乐山市'},
                {id: 385, cityName: '四川省 南充市'},
                {id: 386, cityName: '四川省 宜宾市'},
                {id: 387, cityName: '四川省 广安市'},
                {id: 388, cityName: '四川省 达川地区'},
                {id: 389, cityName: '四川省 雅安地区'},
                {id: 390, cityName: '四川省 阿坝藏族羌族自治州'},
                {id: 391, cityName: '四川省 甘孜藏族自治州'},
                {id: 392, cityName: '四川省 凉山彝族自治州'},
                {id: 393, cityName: '四川省 巴中地区'},
                {id: 394, cityName: '四川省 眉山地区'},
                {id: 395, cityName: '四川省 资阳地区'},
                {id: 396, cityName: '云南省 昆明市'},
                {id: 397, cityName: '云南省 曲靖市'},
                {id: 398, cityName: '云南省 玉溪市'},
                {id: 399, cityName: '云南省 昭通地区'},
                {id: 400, cityName: '云南省 楚雄彝族自治州'},
                {id: 401, cityName: '云南省 红河哈尼族彝族自治州'},
                {id: 402, cityName: '云南省 文山壮族苗族自治州'},
                {id: 403, cityName: '云南省 思茅市'},
                {id: 404, cityName: '云南省 西双版纳傣族自治州'},
                {id: 405, cityName: '云南省 大理白族自治州'},
                {id: 406, cityName: '云南省 保山地区'},
                {id: 407, cityName: '云南省 德宏傣族景颇族自治州'},
                {id: 408, cityName: '云南省 丽江地区'},
                {id: 409, cityName: '云南省 怒江傈僳族自治州'},
                {id: 410, cityName: '云南省 迪庆藏族自治州'},
                {id: 411, cityName: '云南省 临沧地区'},
                {id: 412, cityName: '浙江省 杭州市'},
                {id: 413, cityName: '浙江省 宁波市'},
                {id: 414, cityName: '浙江省 温州市'},
                {id: 415, cityName: '浙江省 嘉兴市'},
                {id: 416, cityName: '浙江省 湖州市'},
                {id: 417, cityName: '浙江省 绍兴市'},
                {id: 418, cityName: '浙江省 金华市'},
                {id: 419, cityName: '浙江省 衢州市'},
                {id: 420, cityName: '浙江省 舟山市'},
                {id: 421, cityName: '浙江省 台州市'},
                {id: 422, cityName: '浙江省 丽水市'},
                {id: 423, cityName: '西藏  拉萨市'},
                {id: 424, cityName: '西藏  昌都地区'},
                {id: 425, cityName: '西藏  山南地区'},
                {id: 426, cityName: '西藏  日喀则地区'},
                {id: 427, cityName: '西藏  那曲地区'},
                {id: 428, cityName: '西藏  阿里地区'},
                {id: 429, cityName: '西藏  林芝地区'},
                {id: 430, cityName: '新疆  乌鲁木齐市'},
                {id: 431, cityName: '新疆  克拉玛依市'},
                {id: 432, cityName: '新疆  吐鲁番地区'},
                {id: 433, cityName: '新疆  哈密地区'},
                {id: 434, cityName: '新疆  昌吉回族自治州'},
                {id: 435, cityName: '新疆  博尔塔拉蒙古自治州'},
                {id: 436, cityName: '新疆  巴音郭楞蒙古自治州'},
                {id: 437, cityName: '新疆  阿克苏地区'},
                {id: 438, cityName: '新疆  克孜勒苏柯尔克孜自治州'},
                {id: 439, cityName: '新疆  喀什地区'},
                {id: 440, cityName: '新疆  和田地区'},
                {id: 441, cityName: '新疆  伊犁哈萨克自治州'},
                {id: 442, cityName: '新疆  塔城地区'},
                {id: 443, cityName: '新疆  阿勒泰地区'},
                {id: 444, cityName: '新疆  石河子市'},
                {id: 445, cityName: '新疆  阿拉尔市'},
                {id: 446, cityName: '新疆  图木舒克市'},
                {id: 447, cityName: '新疆  五家渠市'}
            ];

            var c = _.find(citis, function(i) {
                return i.id === cityId;
            });

            if (c) {
                return c.cityName;
            } else {
                return '上海';
            }
        };
    })
    .filter('cooperationMethod', function() {
        return function(cooperationMethodId) {
            if (!isFinite(cooperationMethodId)) {
                return cooperationMethodId;
            }

            switch (cooperationMethodId) {
                case 10:
                    return '1973';
                case 20:
                    return '自销';
                default:
                    return '1973';
            }
        };
    })
    .filter('time', function() {
        return function(time) {
            if(time === undefined) {
                return undefined;
            }

            if(time.toString().indexOf('选择') >= 0) {
                return time;
            }

            if(time.toString().indexOf('未填写') >= 0) {
                return time;
            }

            return moment(time).format('LL');
        };
    })
    .filter('jobTitle', function() {
        return function(jobId) {
            if (!isFinite(jobId)) {
                return jobId;
            }

            switch (jobId) {
                case 10:
                    return '采购员';
                case 20:
                    return '评估师';
                case 30:
                    return '查询师';
                case 40:
                    return '地区总监';
                case 50:
                    return '总经理';
                default:
                    return jobId;
            }
        };
    })
    .filter('boolState', function() {
        return function(state) {
            if (!isFinite(state)) {
                return state;
            }

            switch (state) {
                case 0:
                    return '正常';
                case 1:
                    return '异常';
                default:
                    return state;
            }
        };
    })
    .filter('saleGrade', function() {
        return function(saleGrade) {
            if (!isFinite(saleGrade)) {
                return saleGrade;
            }

            switch (saleGrade) {
                case 10:
                    return 'A';
                case 20:
                    return 'B';
                case 30:
                    return 'C';
                case 40:
                    return 'D';
                default:
                    return saleGrade;
            }
        };
    })
    .filter('state', function() {
        return function(stateId) {
            if (!isFinite(stateId)) {
                return stateId;
            }

            switch (stateId) {
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