import React, { useState, useEffect } from 'react'

export default props => {
    useEffect(() => {
        fetch("http://localhost:62130/Counters/getValue/720f7015-ada0-4433-b0bb-b6933ce17383")
            .then(response => response.json())
            .then(data => setValue1(data))

        fetch("http://localhost:62130/Counters/getValue/6bcd7898-5d13-4fc4-a738-99291f93849a")
            .then(response => response.json())
            .then(data => setValue2(data))

    }, []);


    const [value1, setValue1] = useState(0)
    const [value2, setValue2] = useState(0)

    const incValue1 = () => setValue1(value1 + 1)
    const decValue1 = () => setValue1(value1 - 1)
    const incValue2 = () => setValue2(value2 + 10)
    const decValue2 = () => setValue2(value2 - 10)

    const saveValue1 = () => {
        fetch("http://localhost:62130/Counters/setValue?counterId=720f7015-ada0-4433-b0bb-b6933ce17383&Value=" + value1, {
            method: 'POST'
        });

    }

    const saveValue2 = () => {
        fetch("http://localhost:62130/Counters/setValue?counterId=6bcd7898-5d13-4fc4-a738-99291f93849a&Value=" + value2, {
            method: 'POST'
        });
    }


    return (
        <div>
        <h1>Counter</h1>

        <p>This is a simple example of a React component.</p>

        <p>Value 1 Current count: <strong>{value1}</strong></p>

        <button onClick={decValue1}>decrement</button>
        <button onClick={saveValue1}>Save</button>
        <button onClick={incValue1}>Increment</button>

        <p>Value 2 Current count: <strong>{value2}</strong></p>

        <button onClick={decValue2}>decrement</button>
        <button onClick={saveValue2}>Save</button>
        <button onClick={incValue2}>Increment</button>



        </div>
)
}