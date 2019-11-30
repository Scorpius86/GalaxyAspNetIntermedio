"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var user_1 = require("../../../models/user");
var OrderEditViewModel = /** @class */ (function () {
    function OrderEditViewModel() {
        this.Clients = new Array();
        this.User = new user_1.User();
        this.ClientId = 0;
    }
    return OrderEditViewModel;
}());
exports.OrderEditViewModel = OrderEditViewModel;
//# sourceMappingURL=edit.viewmodel.js.map