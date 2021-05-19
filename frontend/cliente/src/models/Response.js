export default class Response {
  constructor(isSuccess, message = null, result = null) {
    this.isSuccess = isSuccess;
    this.message = message;
    this.result = result;
  }
}
