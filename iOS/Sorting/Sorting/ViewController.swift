//
//  ViewController.swift
//  Sorting
//
//  Created by Ramasayam, Kranthi on 9/20/20.
//  Copyright © 2020 Ramasayam, Kranthi. All rights reserved.
//

import UIKit

class ViewController: UIViewController {

    @IBOutlet weak var type: UISegmentedControl!
    @IBOutlet weak var inputField: UITextField!
    @IBOutlet weak var inputSortLabel: UILabel!
    @IBOutlet weak var instructionLabel: UILabel!
    
    override func viewDidLoad() {
        super.viewDidLoad()
        // Do any additional setup after loading the view.
    }
    
    
    @IBAction func updateInstruction(_ sender: Any) {
        var label = "Enter comma separated "
               switch type.selectedSegmentIndex {
               case 0:
                   label = label + "integers:"
               break
               case 1:
                   label = label + "strings:"
                   break
               case 2:
                   label = label + "dates:"
                   break
               default:
                   break
               }
        instructionLabel.text = label
    }
    
    @IBAction func sortInputs(_ sender: Any) {
        let input = inputField.text!
        var output = "";
        var label = "Enter comma separated "
        switch type.selectedSegmentIndex {
        case 0:
            label = label + "integers:"
            output = sortIntegers(input: input)
        break
        case 1:
            label = label + "strings:"
            output = sortStrings(input: input)
            break
        case 2:
            label = label + "dates:"
            output = sortDates(input: input)
            break
            
        default:
            break
        }
        
        inputSortLabel.text = output
    }
    
    func sortIntegers(input: String) -> String {
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
        return intArray.description
        
    }
    
    func sortStrings(input: String) -> String {
        var stringArray = input.split(separator: ",")
        
        stringArray = stringArray.sorted { $0.lowercased() < $1.lowercased() }
        return stringArray.description
    }
    
    func sortDates(input: String) -> String {
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
               return stringDates.description    }
}
