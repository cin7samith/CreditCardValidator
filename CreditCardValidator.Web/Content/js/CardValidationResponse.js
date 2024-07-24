class CardValidationResponse {

    #success;
    #message;
    #cardNumber;
    #cardType;
    #createdDateTime;
    constructor(success, message, cardNumber, cardType, createdDateTime) {
        this.#success = success;
        this.#message = message;
        this.#cardNumber = cardNumber;
        this.#cardType = cardType;
        this.#createdDateTime = createdDateTime
    }
    get Success() {
        return this.#success;
    }
    get Message() {
        return this.#message;
    }
    get CardNumber() {
        return this.#cardNumber;
    }
    get CardType() {
        return this.#cardType;
    }
    get CreatedDateTime() {
        return this.#createdDateTime;
    }


    set Success(success) {
        this.#success = success;
    }
    set Message(message) {
        this.#message = message;
    }
    set CardNumber(cardNumber) {
        this.#cardNumber = cardNumber;
    }
    set CardType(cardType) {
        this.#cardType = createdDateTime;
    }
    set CreatedDateTime(createdDateTime) {
        this.#createdDateTime = createdDateTime;
    }
}

