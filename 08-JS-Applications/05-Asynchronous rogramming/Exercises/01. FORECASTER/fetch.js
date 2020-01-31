export function weather() {
    const url = 'https://judgetests.firebaseio.com/';
    return {
        locations: () => fetch(`${url}locations.json`).then(res => res.json()),
        today: (code) => fetch(`${url}forecast/today/${code}.json`).then(res => res.json()),
        upcoming: (code) => fetch(`${url}forecast/upcoming/${code}.json`).then(res => res.json())
    };
}