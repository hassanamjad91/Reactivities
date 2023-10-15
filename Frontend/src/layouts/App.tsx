import { useEffect, useState } from 'react'
import './App.css'
import axios from 'axios'

function App() {
  const [activities, setActivities] = useState([])

  useEffect(() => {
    axios.get('https://localhost:5050/api/activities').then(res => {
      const data = res.data
      if(data)setActivities(res.data)     
    })
  },[])

  return (
    <div>
      <h1>Reactivities</h1>
      <ul> 
        {
        activities.map((activity: any) => (<li>{activity.title}</li>))
        }
      </ul>
    </div>    
  )
}

export default App
