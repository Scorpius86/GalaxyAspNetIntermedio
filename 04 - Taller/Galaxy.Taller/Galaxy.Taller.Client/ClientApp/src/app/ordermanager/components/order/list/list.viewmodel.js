"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var user_1 = require("../../../models/user");
var OrderListViewModel = /** @class */ (function () {
    function OrderListViewModel() {
        this.User = new user_1.User();
        this.OrdersCount = 0;
        this.OrdersTotalMount = 0;
    }
    return OrderListViewModel;
}());
exports.OrderListViewModel = OrderListViewModel;
//# sourceMappingURL=list.viewmodel.js.map