class StorageHelper {
  getNumber = (key: string, fallback: number) => {
    let value = localStorage.getItem(key);
    if(!value) return fallback;
    const parsed = parseInt(value);

    if(isNaN(parsed)) {
      this.removeKey(key);
      return fallback;
    }

    return parsed;
  }

  setNumber = (key: string, value: number) => {
    localStorage.setItem(key, `${value}`);
  };

  removeKey = (key: string) => {
    localStorage.removeItem(key);
  };
}

export const storageHelper = new StorageHelper();
