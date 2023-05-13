//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.19.0.0 (NJsonSchema v10.9.0.0 (Newtonsoft.Json v13.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------

/* tslint:disable */
/* eslint-disable */
// ReSharper disable InconsistentNaming

export interface IGameLocationsClient {

    getGameLocations(locationId: number): Promise<GameLocationEntity[]>;
}

export class GameLocationsClient implements IGameLocationsClient {
    private http: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> };
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(baseUrl?: string, http?: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> }) {
        this.http = http ? http : window as any;
        this.baseUrl = baseUrl !== undefined && baseUrl !== null ? baseUrl : "";
    }

    getGameLocations(locationId: number): Promise<GameLocationEntity[]> {
        let url_ = this.baseUrl + "/GameLocations/{locationId}";
        if (locationId === undefined || locationId === null)
            throw new Error("The parameter 'locationId' must be defined.");
        url_ = url_.replace("{locationId}", encodeURIComponent("" + locationId));
        url_ = url_.replace(/[?&]$/, "");

        let options_: RequestInit = {
            method: "GET",
            headers: {
                "Accept": "application/json"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processGetGameLocations(_response);
        });
    }

    protected processGetGameLocations(response: Response): Promise<GameLocationEntity[]> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            if (Array.isArray(resultData200)) {
                result200 = [] as any;
                for (let item of resultData200)
                    result200!.push(GameLocationEntity.fromJS(item));
            }
            else {
                result200 = <any>null;
            }
            return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<GameLocationEntity[]>(null as any);
    }
}

export interface IGamePlatformsClient {

    getAll(): Promise<GamePlatformEntity[]>;
}

export class GamePlatformsClient implements IGamePlatformsClient {
    private http: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> };
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(baseUrl?: string, http?: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> }) {
        this.http = http ? http : window as any;
        this.baseUrl = baseUrl !== undefined && baseUrl !== null ? baseUrl : "";
    }

    getAll(): Promise<GamePlatformEntity[]> {
        let url_ = this.baseUrl + "/GamePlatforms";
        url_ = url_.replace(/[?&]$/, "");

        let options_: RequestInit = {
            method: "GET",
            headers: {
                "Accept": "application/json"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processGetAll(_response);
        });
    }

    protected processGetAll(response: Response): Promise<GamePlatformEntity[]> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            if (Array.isArray(resultData200)) {
                result200 = [] as any;
                for (let item of resultData200)
                    result200!.push(GamePlatformEntity.fromJS(item));
            }
            else {
                result200 = <any>null;
            }
            return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<GamePlatformEntity[]>(null as any);
    }
}

export interface IGamesClient {

    getAllGames(platformId: number): Promise<BasicGameInfoDto[]>;

    getOrderInformation(gameId: number): Promise<GameOrderInfoDto>;

    getGameImages(gameId: number): Promise<GameImageDto[]>;

    getGameLocations(platformId: number): Promise<GameLocationDto[]>;

    setGameLocation(gameId: number, locationId: number): Promise<number>;

    updateGameInfo(game: BasicGameInfoDto): Promise<number>;
}

export class GamesClient implements IGamesClient {
    private http: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> };
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(baseUrl?: string, http?: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> }) {
        this.http = http ? http : window as any;
        this.baseUrl = baseUrl !== undefined && baseUrl !== null ? baseUrl : "";
    }

    getAllGames(platformId: number): Promise<BasicGameInfoDto[]> {
        let url_ = this.baseUrl + "/Games/{platformId}";
        if (platformId === undefined || platformId === null)
            throw new Error("The parameter 'platformId' must be defined.");
        url_ = url_.replace("{platformId}", encodeURIComponent("" + platformId));
        url_ = url_.replace(/[?&]$/, "");

        let options_: RequestInit = {
            method: "GET",
            headers: {
                "Accept": "application/json"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processGetAllGames(_response);
        });
    }

    protected processGetAllGames(response: Response): Promise<BasicGameInfoDto[]> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            if (Array.isArray(resultData200)) {
                result200 = [] as any;
                for (let item of resultData200)
                    result200!.push(BasicGameInfoDto.fromJS(item));
            }
            else {
                result200 = <any>null;
            }
            return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<BasicGameInfoDto[]>(null as any);
    }

    getOrderInformation(gameId: number): Promise<GameOrderInfoDto> {
        let url_ = this.baseUrl + "/Games/order-info/{gameId}";
        if (gameId === undefined || gameId === null)
            throw new Error("The parameter 'gameId' must be defined.");
        url_ = url_.replace("{gameId}", encodeURIComponent("" + gameId));
        url_ = url_.replace(/[?&]$/, "");

        let options_: RequestInit = {
            method: "GET",
            headers: {
                "Accept": "application/json"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processGetOrderInformation(_response);
        });
    }

    protected processGetOrderInformation(response: Response): Promise<GameOrderInfoDto> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = GameOrderInfoDto.fromJS(resultData200);
            return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<GameOrderInfoDto>(null as any);
    }

    getGameImages(gameId: number): Promise<GameImageDto[]> {
        let url_ = this.baseUrl + "/Games/images/{gameId}";
        if (gameId === undefined || gameId === null)
            throw new Error("The parameter 'gameId' must be defined.");
        url_ = url_.replace("{gameId}", encodeURIComponent("" + gameId));
        url_ = url_.replace(/[?&]$/, "");

        let options_: RequestInit = {
            method: "GET",
            headers: {
                "Accept": "application/json"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processGetGameImages(_response);
        });
    }

    protected processGetGameImages(response: Response): Promise<GameImageDto[]> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            if (Array.isArray(resultData200)) {
                result200 = [] as any;
                for (let item of resultData200)
                    result200!.push(GameImageDto.fromJS(item));
            }
            else {
                result200 = <any>null;
            }
            return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<GameImageDto[]>(null as any);
    }

    getGameLocations(platformId: number): Promise<GameLocationDto[]> {
        let url_ = this.baseUrl + "/Games/locations/{platformId}";
        if (platformId === undefined || platformId === null)
            throw new Error("The parameter 'platformId' must be defined.");
        url_ = url_.replace("{platformId}", encodeURIComponent("" + platformId));
        url_ = url_.replace(/[?&]$/, "");

        let options_: RequestInit = {
            method: "GET",
            headers: {
                "Accept": "application/json"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processGetGameLocations(_response);
        });
    }

    protected processGetGameLocations(response: Response): Promise<GameLocationDto[]> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            if (Array.isArray(resultData200)) {
                result200 = [] as any;
                for (let item of resultData200)
                    result200!.push(GameLocationDto.fromJS(item));
            }
            else {
                result200 = <any>null;
            }
            return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<GameLocationDto[]>(null as any);
    }

    setGameLocation(gameId: number, locationId: number): Promise<number> {
        let url_ = this.baseUrl + "/Games/set-location/{gameId}/{locationId}";
        if (gameId === undefined || gameId === null)
            throw new Error("The parameter 'gameId' must be defined.");
        url_ = url_.replace("{gameId}", encodeURIComponent("" + gameId));
        if (locationId === undefined || locationId === null)
            throw new Error("The parameter 'locationId' must be defined.");
        url_ = url_.replace("{locationId}", encodeURIComponent("" + locationId));
        url_ = url_.replace(/[?&]$/, "");

        let options_: RequestInit = {
            method: "PUT",
            headers: {
                "Accept": "application/json"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processSetGameLocation(_response);
        });
    }

    protected processSetGameLocation(response: Response): Promise<number> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
                result200 = resultData200 !== undefined ? resultData200 : <any>null;
    
            return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<number>(null as any);
    }

    updateGameInfo(game: BasicGameInfoDto): Promise<number> {
        let url_ = this.baseUrl + "/Games/update";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(game);

        let options_: RequestInit = {
            body: content_,
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Accept": "application/json"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processUpdateGameInfo(_response);
        });
    }

    protected processUpdateGameInfo(response: Response): Promise<number> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
                result200 = resultData200 !== undefined ? resultData200 : <any>null;
    
            return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<number>(null as any);
    }
}

export interface IImageClient {

    getImage(platform: string, gameId: number): Promise<FileResponse | null>;
}

export class ImageClient implements IImageClient {
    private http: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> };
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(baseUrl?: string, http?: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> }) {
        this.http = http ? http : window as any;
        this.baseUrl = baseUrl !== undefined && baseUrl !== null ? baseUrl : "";
    }

    getImage(platform: string, gameId: number): Promise<FileResponse | null> {
        let url_ = this.baseUrl + "/Image/game/{platform}/{gameId}";
        if (platform === undefined || platform === null)
            throw new Error("The parameter 'platform' must be defined.");
        url_ = url_.replace("{platform}", encodeURIComponent("" + platform));
        if (gameId === undefined || gameId === null)
            throw new Error("The parameter 'gameId' must be defined.");
        url_ = url_.replace("{gameId}", encodeURIComponent("" + gameId));
        url_ = url_.replace(/[?&]$/, "");

        let options_: RequestInit = {
            method: "GET",
            headers: {
                "Accept": "application/octet-stream"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processGetImage(_response);
        });
    }

    protected processGetImage(response: Response): Promise<FileResponse | null> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200 || status === 206) {
            const contentDisposition = response.headers ? response.headers.get("content-disposition") : undefined;
            let fileNameMatch = contentDisposition ? /filename\*=(?:(\\?['"])(.*?)\1|(?:[^\s]+'.*?')?([^;\n]*))/g.exec(contentDisposition) : undefined;
            let fileName = fileNameMatch && fileNameMatch.length > 1 ? fileNameMatch[3] || fileNameMatch[2] : undefined;
            if (fileName) {
                fileName = decodeURIComponent(fileName);
            } else {
                fileNameMatch = contentDisposition ? /filename="?([^"]*?)"?(;|$)/g.exec(contentDisposition) : undefined;
                fileName = fileNameMatch && fileNameMatch.length > 1 ? fileNameMatch[1] : undefined;
            }
            return response.blob().then(blob => { return { fileName: fileName, data: blob, status: status, headers: _headers }; });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<FileResponse | null>(null as any);
    }
}

export class GameLocationEntity implements IGameLocationEntity {
    locationID!: number;
    platformID!: number;
    locationName!: string;

    constructor(data?: IGameLocationEntity) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.locationID = _data["locationID"];
            this.platformID = _data["platformID"];
            this.locationName = _data["locationName"];
        }
    }

    static fromJS(data: any): GameLocationEntity {
        data = typeof data === 'object' ? data : {};
        let result = new GameLocationEntity();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["locationID"] = this.locationID;
        data["platformID"] = this.platformID;
        data["locationName"] = this.locationName;
        return data;
    }
}

export interface IGameLocationEntity {
    locationID: number;
    platformID: number;
    locationName: string;
}

export class GamePlatformEntity implements IGamePlatformEntity {
    platformID!: number;
    platformName!: string;

    constructor(data?: IGamePlatformEntity) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.platformID = _data["platformID"];
            this.platformName = _data["platformName"];
        }
    }

    static fromJS(data: any): GamePlatformEntity {
        data = typeof data === 'object' ? data : {};
        let result = new GamePlatformEntity();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["platformID"] = this.platformID;
        data["platformName"] = this.platformName;
        return data;
    }
}

export interface IGamePlatformEntity {
    platformID: number;
    platformName: string;
}

export class BasicGameInfoDto implements IBasicGameInfoDto {
    gameID!: number;
    gameName!: string;
    platformID!: number;
    locationID!: number;
    gameCase!: string;
    hasCover!: boolean;
    rating!: number;
    imagePath!: string;
    locationName!: string;
    platformName!: string;
    hasProtection!: boolean;
    seller!: string;
    orderNumber!: string;
    cost!: number;
    purchaseDate?: Date | undefined;
    gameSold!: boolean;

    constructor(data?: IBasicGameInfoDto) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.gameID = _data["gameID"];
            this.gameName = _data["gameName"];
            this.platformID = _data["platformID"];
            this.locationID = _data["locationID"];
            this.gameCase = _data["gameCase"];
            this.hasCover = _data["hasCover"];
            this.rating = _data["rating"];
            this.imagePath = _data["imagePath"];
            this.locationName = _data["locationName"];
            this.platformName = _data["platformName"];
            this.hasProtection = _data["hasProtection"];
            this.seller = _data["seller"];
            this.orderNumber = _data["orderNumber"];
            this.cost = _data["cost"];
            this.purchaseDate = _data["purchaseDate"] ? new Date(_data["purchaseDate"].toString()) : <any>undefined;
            this.gameSold = _data["gameSold"];
        }
    }

    static fromJS(data: any): BasicGameInfoDto {
        data = typeof data === 'object' ? data : {};
        let result = new BasicGameInfoDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["gameID"] = this.gameID;
        data["gameName"] = this.gameName;
        data["platformID"] = this.platformID;
        data["locationID"] = this.locationID;
        data["gameCase"] = this.gameCase;
        data["hasCover"] = this.hasCover;
        data["rating"] = this.rating;
        data["imagePath"] = this.imagePath;
        data["locationName"] = this.locationName;
        data["platformName"] = this.platformName;
        data["hasProtection"] = this.hasProtection;
        data["seller"] = this.seller;
        data["orderNumber"] = this.orderNumber;
        data["cost"] = this.cost;
        data["purchaseDate"] = this.purchaseDate ? this.purchaseDate.toISOString() : <any>undefined;
        data["gameSold"] = this.gameSold;
        return data;
    }
}

export interface IBasicGameInfoDto {
    gameID: number;
    gameName: string;
    platformID: number;
    locationID: number;
    gameCase: string;
    hasCover: boolean;
    rating: number;
    imagePath: string;
    locationName: string;
    platformName: string;
    hasProtection: boolean;
    seller: string;
    orderNumber: string;
    cost: number;
    purchaseDate?: Date | undefined;
    gameSold: boolean;
}

export class GameOrderInfoDto implements IGameOrderInfoDto {
    gameID!: number;
    hasProtection!: boolean;
    seller!: string;
    orderNumber!: string;
    cost!: number;
    purchaseDate!: Date;

    constructor(data?: IGameOrderInfoDto) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.gameID = _data["gameID"];
            this.hasProtection = _data["hasProtection"];
            this.seller = _data["seller"];
            this.orderNumber = _data["orderNumber"];
            this.cost = _data["cost"];
            this.purchaseDate = _data["purchaseDate"] ? new Date(_data["purchaseDate"].toString()) : <any>undefined;
        }
    }

    static fromJS(data: any): GameOrderInfoDto {
        data = typeof data === 'object' ? data : {};
        let result = new GameOrderInfoDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["gameID"] = this.gameID;
        data["hasProtection"] = this.hasProtection;
        data["seller"] = this.seller;
        data["orderNumber"] = this.orderNumber;
        data["cost"] = this.cost;
        data["purchaseDate"] = this.purchaseDate ? this.purchaseDate.toISOString() : <any>undefined;
        return data;
    }
}

export interface IGameOrderInfoDto {
    gameID: number;
    hasProtection: boolean;
    seller: string;
    orderNumber: string;
    cost: number;
    purchaseDate: Date;
}

export class GameImageDto implements IGameImageDto {
    gameID!: number;
    imageType!: string;
    imageOrder!: number;
    imagePath!: string;

    constructor(data?: IGameImageDto) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.gameID = _data["gameID"];
            this.imageType = _data["imageType"];
            this.imageOrder = _data["imageOrder"];
            this.imagePath = _data["imagePath"];
        }
    }

    static fromJS(data: any): GameImageDto {
        data = typeof data === 'object' ? data : {};
        let result = new GameImageDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["gameID"] = this.gameID;
        data["imageType"] = this.imageType;
        data["imageOrder"] = this.imageOrder;
        data["imagePath"] = this.imagePath;
        return data;
    }
}

export interface IGameImageDto {
    gameID: number;
    imageType: string;
    imageOrder: number;
    imagePath: string;
}

export class GameLocationDto implements IGameLocationDto {
    locationID!: number;
    platformID!: number;
    locationName!: string;

    constructor(data?: IGameLocationDto) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.locationID = _data["locationID"];
            this.platformID = _data["platformID"];
            this.locationName = _data["locationName"];
        }
    }

    static fromJS(data: any): GameLocationDto {
        data = typeof data === 'object' ? data : {};
        let result = new GameLocationDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["locationID"] = this.locationID;
        data["platformID"] = this.platformID;
        data["locationName"] = this.locationName;
        return data;
    }
}

export interface IGameLocationDto {
    locationID: number;
    platformID: number;
    locationName: string;
}

export interface FileResponse {
    data: Blob;
    status: number;
    fileName?: string;
    headers?: { [name: string]: any };
}

export class ApiException extends Error {
    override message: string;
    status: number;
    response: string;
    headers: { [key: string]: any; };
    result: any;

    constructor(message: string, status: number, response: string, headers: { [key: string]: any; }, result: any) {
        super();

        this.message = message;
        this.status = status;
        this.response = response;
        this.headers = headers;
        this.result = result;
    }

    protected isApiException = true;

    static isApiException(obj: any): obj is ApiException {
        return obj.isApiException === true;
    }
}

function throwException(message: string, status: number, response: string, headers: { [key: string]: any; }, result?: any): any {
    throw new ApiException(message, status, response, headers, result);
}