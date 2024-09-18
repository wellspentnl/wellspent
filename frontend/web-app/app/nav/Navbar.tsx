import React from 'react'
import { SiGooglecolab } from "react-icons/si";

export default function Navbar() {
  return (
    <header className='
        sticky top-0 z-50 flex justify-between bg-white p-5 items-center text-gray-800 shadow-md'>
        <div className='flex items-center gap-2 text-xl font-semibold'>
            <SiGooglecolab />
            <div>wellspent</div>
        </div>
        <div>Middle</div> 
        <div>Right</div>   
    </header>
  )
}
