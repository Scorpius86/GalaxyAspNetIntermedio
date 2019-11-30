"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var product_1 = require("../../../../models/product");
var order_1 = require("../../../../models/order");
var OrderProductDeleteViewModel = /** @class */ (function () {
    function OrderProductDeleteViewModel() {
        this.Product = new product_1.Product();
        this.Order = new order_1.Order();
        this.Quantity = 0;
    }
    return OrderProductDeleteViewModel;
}());
exports.OrderProductDeleteViewModel = OrderProductDeleteViewModel;
//# sourceMappingURL=delete.viewmodel.js.map