//
//  ViewController.swift
//  Sorting
//
//  Created by Ramasayam, Kranthi on 9/20/20.
//  Copyright © 2020 Ramasayam, Kranthi. All rights reserved.
//

import UIKit

class ViewController: UIViewController {

        
    override func viewDidLoad() {
        super.viewDidLoad()
        // Do any additional setup after loading the view.
    }
    
    @IBOutlet weak var intField: UITextField!
    @IBOutlet weak var intSortLabel: UILabel!
    @IBAction func sortIntegers(_ sender: Any) {
        let input = intField.text!
        var intArray: Array<Int> = Array()
        let stringArray = input.split(separator: ",")
        for str in stringArray
            {
                let intConvert: Int? = Int(String(str))
                if intConvert != nil
                {
                    intArray.append((intConvert)!)
                }
               
            }
        
        
        intArray.sort()
        intSortLabel.text = intArray.description
        
    }
    
    @IBOutlet weak var stringField: UITextField!
    @IBOutlet weak var stringSortLabel: UILabel!
    @IBAction func sortStrings(_ sender: Any) {
        let input = stringField.text!
        var stringArray = input.split(separator: ",")
        
        stringArray = stringArray.sorted { $0.lowercased() < $1.lowercased() }
        stringSortLabel.text = stringArray.description
    }
    
    @IBOutlet weak var datesField: UITextField!
    @IBOutlet weak var datesSortLabel: UILabel!
    @IBAction func sortDates(_ sender: Any) {
         let input = datesField.text!
               var intArray: Array<Date> = Array()
               let stringArray = input.split(separator: ",")
        let dateFormatter = DateFormatter()
        dateFormatter.locale = Locale(identifier: "en_US_POSIX") // set locale to reliable US_POSIX
        dateFormatter.dateFormat = "MM/dd/yyyy"
               for str in stringArray
                   {
                    
                    let intConvert: Date? = dateFormatter.date(from: String(str))
                       if intConvert != nil
                       {
                           intArray.append((intConvert)!)
                       }
                   }
               
               intArray.sort()
        
        var stringDates: Array<String> = [];
        for date in intArray {
            stringDates.append(dateFormatter.string(from: date))
        }
               datesSortLabel.text = stringDates.description    }
}
