"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var user_1 = require("../../models/user");
var list_viewmodel_1 = require("../order/list/list.viewmodel");
var list_viewmodel_2 = require("../order/product/list/list.viewmodel");
var MainContentViewModel = /** @class */ (function () {
    function MainContentViewModel() {
        this.User = new user_1.User();
        this.OrderListViewModel = new list_viewmodel_1.OrderListViewModel();
        this.OrderProductListViewModel = new list_viewmodel_2.OrderProductListViewModel();
    }
    return MainContentViewModel;
}());
exports.MainContentViewModel = MainContentViewModel;
//# sourceMappingURL=main-content.viewmodel.js.map