"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var order_1 = require("../../../../models/order");
var OrderProductEditViewModel = /** @class */ (function () {
    function OrderProductEditViewModel() {
        this.Products = new Array();
        this.Order = new order_1.Order();
        this.ProductId = 0;
        this.Quantity = 0;
    }
    return OrderProductEditViewModel;
}());
exports.OrderProductEditViewModel = OrderProductEditViewModel;
//# sourceMappingURL=edit.viewmodel.js.map