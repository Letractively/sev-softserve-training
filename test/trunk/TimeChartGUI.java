package com.sevntu.apvs.timeChart;


import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.Component;
import java.awt.Dimension;
import java.awt.FileDialog;
import java.awt.FlowLayout;
import java.awt.Font;
import java.awt.GridBagConstraints;
import java.awt.GridBagLayout;
import java.awt.Image;
import java.awt.Insets;
import java.awt.Toolkit;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.InputEvent;
import java.awt.event.KeyEvent;
import java.util.ArrayList;
import javax.swing.Box;
import javax.swing.ButtonGroup;
import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JMenu;
import javax.swing.JMenuBar;
import javax.swing.JMenuItem;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JRadioButton;
import javax.swing.JScrollPane;
import javax.swing.JTabbedPane;
import javax.swing.JTable;
import javax.swing.JTextField;
import javax.swing.KeyStroke;
import javax.swing.SwingUtilities;
import javax.swing.UIManager;
import javax.swing.UnsupportedLookAndFeelException;
import javax.swing.border.BevelBorder;
import javax.swing.event.ChangeEvent;
import javax.swing.event.ChangeListener;
import javax.swing.table.AbstractTableModel;

public class TimeChartGUI implements ActionListener
{
	
	private JFrame GUI;
	private JTable t;
	private JLabel Status; 
	private JMenu jmFile,jmHelp;
    private JTabbedPane tabPane,settingsPane;
    private JPanel jpSetup,jpCircuit,jpElement;
    private JRadioButton jrb1,jrb2,jrb3,jrb4,jrb5,jrb6;
    private JMenuItem jmiOpen,jmiSave,jmiExit,jmiAbout;
    private JTextField jtf1,jtf2,jtf3,jtf4,jtf5,jtf6,jtf7,jtf8,jtf9;
    private static int paneIndex;
    static ArrayList <DiagramInfo> obj;
    static ArrayList <pinList> infoList = null;
    
    public TimeChartGUI (String protocol, String info)
    {
    	paneIndex = 0;
    	setCrossPlatformLookAndFeel();
    	obj = new ArrayList <DiagramInfo> ();
    	GUI = new JFrame ("Временные диаграммы.");
		Image frmImage = Toolkit.getDefaultToolkit().getImage("icons\\chart.png");
        GUI.setIconImage(frmImage);
        GUI.setSize(1100,825);
        Dimension screenSize = Toolkit.getDefaultToolkit().getScreenSize();
        GUI.setLocation((screenSize.width - GUI.getWidth()) / 2,(screenSize.height - GUI.getHeight()) / 4);
        GUI.setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE);
        GUI.setLayout(new FlowLayout(FlowLayout.CENTER));
        GUI.getContentPane().setBackground(new Color (212,208,200));
        JMenuBar jmb = new JMenuBar();
        jmFile = new JMenu ("Файл");
        jmiOpen = new JMenuItem ("Загрузить протокол...",new ImageIcon ("icons/open.png"));
        jmiOpen.setAccelerator(KeyStroke.getKeyStroke(KeyEvent.VK_O,InputEvent.CTRL_MASK));
        jmiOpen.addActionListener(this);
        jmFile.add(jmiOpen);
        jmiSave = new JMenuItem ("Сохранить диаграмму",new ImageIcon ("icons/save.png"));
        jmiSave.setAccelerator(KeyStroke.getKeyStroke(KeyEvent.VK_S,InputEvent.CTRL_MASK));
        jmiSave.addActionListener(this);
        jmFile.add(jmiSave);
        jmiExit = new JMenuItem ("Выход",new ImageIcon ("icons/close.png"));
        jmiExit.setAccelerator(KeyStroke.getKeyStroke(KeyEvent.VK_E,InputEvent.CTRL_MASK));
        jmiExit.addActionListener(this);
        jmFile.add(jmiExit);
        jmb.add(jmFile);
        jmHelp = new JMenu ("Справка");
        jmiAbout = new JMenuItem ("О программе...",new ImageIcon ("icons/info.png"));
        jmiAbout.setAccelerator(KeyStroke.getKeyStroke("F2"));
        jmiAbout.addActionListener(this);
        jmHelp.add(jmiAbout);
        jmb.add(jmHelp);
        GUI.setJMenuBar(jmb);
        tabPane = new JTabbedPane();
        tabPane.addChangeListener(new ChangeListener() 
        {
			public void stateChanged(ChangeEvent evt)
        	{
                JTabbedPane pane = (JTabbedPane)evt.getSource();
                int sel = pane.getSelectedIndex();
                if (obj.size() > 0)
                {
                	infoList = obj.get(sel).chart.getPinList();
                    AbstractTableModel atm = (AbstractTableModel) t.getModel();
                    atm.fireTableDataChanged();
                }
            }
        });
        tabPane.add("Основная диаграмма",new JPanel());
        initTabComponent(paneIndex);
        tabPane.setPreferredSize(new Dimension (1080,502));
        Chart cc = new Chart("ВРЕМЕННЫЕ ДИАГРАММЫ","ВРЕМЯ (ms)","НОМЕРА ЦЕПЕЙ");
        obj.add(tabPane.getSelectedIndex(),new DiagramInfo (cc,protocol,info));
    	((JPanel) tabPane.getComponentAt(paneIndex)).add(cc.getChart());
    	((JPanel) tabPane.getComponentAt(paneIndex)).add(cc.getVerticalScrollBar());
    	((JPanel) tabPane.getComponentAt(paneIndex)).add(cc.getHorizontalScrollBar());
    	((JPanel) tabPane.getComponentAt(paneIndex)).updateUI();
        GUI.add(tabPane);
        jpSetup = new JPanel ();
        jpSetup.setBackground(new Color (212,208,200));
        jpCircuit = new JPanel();
        jpCircuit.setLayout(new GridBagLayout());
        GridBagConstraints gbc = new GridBagConstraints();
        gbc.anchor = GridBagConstraints.WEST;
        gbc.insets = new Insets (0,5,10,0);
        gbc.weightx = 0.0;
        gbc.gridx = 0; gbc.gridy = 0;
        jpCircuit.add(new JLabel("<html> <u>Режимы фильтопции</u>: </html>"),gbc);
        ButtonGroup circuitGroup = new ButtonGroup();
        jrb1 = new JRadioButton("Отобразить все цепи",true);
        circuitGroup.add(jrb1);
        gbc.gridx = 0; gbc.gridy = 1;
        jpCircuit.add(jrb1,gbc);
        jrb2 = new JRadioButton("Отобразить одну цепь");
        circuitGroup.add(jrb2);
        gbc.gridx = 0; gbc.gridy = 2;
        jpCircuit.add(jrb2,gbc);
        jrb3 = new JRadioButton("Отобразить диапазон цепей");
        circuitGroup.add(jrb3);
        gbc.gridx = 0; gbc.gridy = 3;
        jpCircuit.add(jrb3,gbc);
        gbc.gridx = 1; gbc.gridy = 2;
        jpCircuit.add(new JLabel("   Номер цепи:"),gbc);
        jtf1 = new JTextField(3);
        jtf1.setDocument(new JTextFieldFilter(JTextFieldFilter.NUMERIC));
        gbc.gridx = 2; gbc.gridy = 2;
        jpCircuit.add(jtf1,gbc);
        gbc.gridx = 1; gbc.gridy = 3;
        jpCircuit.add(new JLabel("       Диапазон:"),gbc);   
        jtf2 = new JTextField(3);
        jtf2.setDocument(new JTextFieldFilter(JTextFieldFilter.NUMERIC));
        gbc.gridx = 2; gbc.gridy = 3;
        jpCircuit.add(jtf2,gbc);
        gbc.gridx = 3; gbc.gridy = 3;
        jpCircuit.add(new JLabel("-"),gbc);
        jtf3 = new JTextField(3);
        jtf3.setDocument(new JTextFieldFilter(JTextFieldFilter.NUMERIC));
        gbc.gridx = 4; gbc.gridy = 3;
        jpCircuit.add(jtf3,gbc);
        gbc.weightx = 1.0;
        jpCircuit.add(new JLabel(),gbc);
        jpElement = new JPanel();
        jpElement.setLayout(new GridBagLayout());
        ButtonGroup elementGroup = new ButtonGroup();
        gbc.weightx = 0.0;
        gbc.gridx = 0; gbc.gridy = 0;
        jpElement.add(new JLabel("<html> <u>Режимы фильтрации</u>: </html>"),gbc);
        jrb4 = new JRadioButton("По номеру элемента",true);
        elementGroup.add(jrb4);
        gbc.gridx = 0; gbc.gridy = 1;
        jpElement.add(jrb4,gbc);
        jrb5 = new JRadioButton("По номеру контакта");
        elementGroup.add(jrb5);
        gbc.gridx = 0; gbc.gridy = 2;
        jpElement.add(jrb5,gbc);
        jrb6 = new JRadioButton("По диапазону цепей");
        elementGroup.add(jrb6);
        gbc.gridx = 0; gbc.gridy = 3;
        jpElement.add(jrb6,gbc);
        gbc.gridx = 1; gbc.gridy = 1;
        jpElement.add(new JLabel("  № Элемента:"),gbc);
        gbc.gridx = 1; gbc.gridy = 2;
        jpElement.add(new JLabel("  № Элемента:"),gbc);
        gbc.gridx = 1; gbc.gridy = 3;
        jpElement.add(new JLabel("  № Элемента:"),gbc);
        jtf4 = new JTextField(3);
        jtf4.setDocument(new JTextFieldFilter(JTextFieldFilter.NUMERIC));
        gbc.gridx = 2; gbc.gridy = 1;
        jpElement.add(jtf4,gbc);
        jtf5 = new JTextField(3);
        jtf5.setDocument(new JTextFieldFilter(JTextFieldFilter.NUMERIC));
        gbc.gridx = 2; gbc.gridy = 2;
        jpElement.add(jtf5,gbc);
        jtf6 = new JTextField(3);
        jtf6.setDocument(new JTextFieldFilter(JTextFieldFilter.NUMERIC));
        gbc.gridx = 2; gbc.gridy = 3;
        jpElement.add(jtf6,gbc);
        gbc.gridx = 3; gbc.gridy = 2;
        jpElement.add(new JLabel("№ Контакта:"),gbc);
        gbc.gridx = 3; gbc.gridy = 3;
        jpElement.add(new JLabel("   Диапазон:"),gbc);
        jtf7 = new JTextField(3);
        jtf7.setDocument(new JTextFieldFilter(JTextFieldFilter.NUMERIC));
        gbc.gridx = 4; gbc.gridy = 2;
        jpElement.add(jtf7,gbc);
        jtf8 = new JTextField(3);
        jtf8.setDocument(new JTextFieldFilter(JTextFieldFilter.NUMERIC));
        gbc.gridx = 4; gbc.gridy = 3;
        jpElement.add(jtf8,gbc);
        gbc.gridx = 5; gbc.gridy = 3;
        jpElement.add(new JLabel("-"),gbc);
        jtf9 = new JTextField(3);
        jtf9.setDocument(new JTextFieldFilter(JTextFieldFilter.NUMERIC));
        gbc.gridx = 6; gbc.gridy = 3;
        jpElement.add(jtf9,gbc);
        gbc.weightx = 1.0;
        jpElement.add(new JLabel(),gbc);
        settingsPane = new JTabbedPane();
        settingsPane.setPreferredSize(new Dimension(510, 180));
        settingsPane.addTab("Фильтр по цепям",jpCircuit);
        settingsPane.addTab("Фильтр по элементам",jpElement);
        jpSetup.add(settingsPane);
        GUI.add (jpSetup);
        Box box = Box.createVerticalBox();
        box.add(Box.createHorizontalStrut(100));
        box.add(new JLabel("<html><u><b>ДОПОЛНИТЕЛЬНАЯ ИНФОРМАЦИЯ</b></u></html>"));
        box.add(Box.createVerticalStrut(5));
        Table myTable = new Table ();
        t = myTable.getTable();
        JScrollPane jsp = new JScrollPane (t);
        jsp.setPreferredSize(new Dimension(550, 158));
        box.add (jsp);
        GUI.add(box);
        JButton show = new JButton ("ОБНОВИТЬ ДИАГРАММУ",new ImageIcon ("icons/show.png"));
        show.addActionListener(this);
        GUI.add(show);
        JPanel jp_status = new JPanel();
        jp_status.setLayout(new BorderLayout());
        jp_status.setPreferredSize(new Dimension(1095, 25));
        Status = new JLabel("  Программа работает...");
        jp_status.add(Status, BorderLayout.CENTER);
        jp_status.setBorder(new BevelBorder(BevelBorder.LOWERED));
        GUI.add(jp_status,BorderLayout.SOUTH);
        Font font = new Font("Times New Roman", Font.PLAIN, 12);
        setFontForAll(GUI, font);
        GUI.setResizable(false);
        GUI.setVisible(true);

    }
    
    private void setFontForAll(JFrame f, Font font)
    { 
        f.setFont(font); 
        setFontRecursive(f.getContentPane().getComponents(), font); 
    } 
    
    private static void setFontRecursive(Component [] components, java.awt.Font font)
    { 
        for (Component c : components)
        { 
            c.setFont(font); 
            if (c instanceof java.awt.Container) 
             setFontRecursive(((java.awt.Container)c).getComponents(), font); 
        } 
    } 
    private void setCrossPlatformLookAndFeel()
    {
    	try 
    	{
    		UIManager.setLookAndFeel (UIManager.getCrossPlatformLookAndFeelClassName());
	    } 
	    catch (UnsupportedLookAndFeelException e)
	    {
	    	e.printStackTrace();
	    }
	    catch (ClassNotFoundException e)
	    {
	    	e.printStackTrace();
	    }
	    catch (InstantiationException e)
	    {
	    	e.printStackTrace();
	    }
	    catch (IllegalAccessException e)
	    {
	        e.printStackTrace();
	    } 
    }   
    private void initTabComponent(int i)
    {
        tabPane.setTabComponentAt(i, new TabButtons(tabPane));
    }    
    
	public void actionPerformed (ActionEvent e)
	{
		String command = e.getActionCommand();
        if (command.equals ("Загрузить протокол..."))
        {
        	FileDialog fdlg = new FileDialog(new JFrame(),"Загрузка протокола",FileDialog.LOAD);
            fdlg.setFile ("protocol*.txt");
            fdlg.setDirectory ("input");
            fdlg.setVisible(true);
            if (fdlg.getFile() != null)
            {
            	FileDialog nextfdlg = new FileDialog(new JFrame(),"Загрузка дополнительной информации",FileDialog.LOAD);
            	nextfdlg.setFile ("info*.txt");
            	nextfdlg.setDirectory ("input");
            	nextfdlg.setVisible(true);
                if (nextfdlg.getFile() != null)
                {
                	paneIndex++;
                    String title = "Диаграмма [" + fdlg.getFile() + "]";
                    tabPane.add(title,new JPanel());
                    initTabComponent(paneIndex);
                    JPanel pane = ((JPanel) tabPane.getComponentAt(paneIndex));
            	    Chart cc = new Chart(fdlg.getDirectory() + fdlg.getFile(),nextfdlg.getDirectory() + nextfdlg.getFile(),"ВРЕМЕННЫЕ ДИАГРАММЫ","ВРЕМЯ (ms)","НОМЕРА ЦЕПЕЙ",null);
            	    obj.add(paneIndex,new DiagramInfo (cc,fdlg.getDirectory() + fdlg.getFile(),nextfdlg.getDirectory() + nextfdlg.getFile()));
            	    pane.removeAll();
            	    pane.add(cc.getChart());
            	    pane.add(cc.getVerticalScrollBar());
            	    pane.add(cc.getHorizontalScrollBar());
            	    pane.updateUI();
            	    tabPane.setSelectedIndex(paneIndex);
                }
            }
        }		
        else
        if (command.equals ("ОБНОВИТЬ ДИАГРАММУ"))
        {
        	int myList [] = null;
        	boolean error = false;
        	if (settingsPane.getSelectedIndex() == 0)
        	{
        		if (jrb2.isSelected())	
        		{
        			if (jtf1.getText().equals(""))
        			{
        				JOptionPane.showMessageDialog(new JFrame(),"Введите номер цепи !","Сообщение",JOptionPane.ERROR_MESSAGE);
        			    error = true;
        			}
        			else
        			{
        				myList = new int [1];
            	        myList[0] = Integer.parseInt(jtf1.getText())-1;
        			}
        		}
        		else
        		if (jrb3.isSelected())
        		{
        			if (jtf2.getText().equals("") || jtf3.getText().equals(""))
        			{
        				JOptionPane.showMessageDialog(new JFrame(),"Введите диапазон !","Сообщение",JOptionPane.ERROR_MESSAGE);
        			    error = true;
        			}
        			else
            		if (Integer.parseInt (jtf2.getText()) >= Integer.parseInt(jtf3.getText()))
            		{
            		    JOptionPane.showMessageDialog(new JFrame(),"Диапазон указан не верно !","Сообщение",JOptionPane.ERROR_MESSAGE);
            			error = true;
            	    }
            		else
            		{
            			int Numb_1 = Integer.parseInt(jtf2.getText());
            			int Numb_2 = Integer.parseInt(jtf3.getText());
            			myList = new int [Numb_2-Numb_1+1];
            			for (int i=Numb_1;i<=Numb_2;i++)
            			{
            				myList[i-Numb_1]=i-1;
            			}
            		}
        		}
        	}
        	else
        	{
        		if (jrb4.isSelected())
        		{
        			if (jtf4.getText().equals(""))
        			{
        				JOptionPane.showMessageDialog(new JFrame(),"Введите номер элемента !","Сообщение",JOptionPane.ERROR_MESSAGE);
        			    error = true;
        			}
        			else
        			{
        				int Value = Integer.parseInt(jtf4.getText());
        				String str = new String("");
        				String Temp[];
        				for (int i=0;i<infoList.size();i++)
        				{
        					if (Value == infoList.get(i).firstNumb || Value == infoList.get(i).secondNumb)
        					{
        						str = str + Integer.toString(infoList.get(i).circuit-1) + " ";
        					}
        				}
        				if (str.equals(""))
        				{
        					JOptionPane.showMessageDialog(new JFrame(),"Такого элемента не существует !","Сообщение",JOptionPane.ERROR_MESSAGE);
            			    error = true;
        				}
        				else
        				{
            				Temp = str.split("\\s+");
            				myList = new int [Temp.length];
            				for (int i=0;i<myList.length;i++)
            				myList[i] = Integer.parseInt(Temp[i]);
        				}
        			}
        		}
        		else
        		if (jrb5.isSelected())	
        		{
        			if (jtf5.getText().equals("") || jtf7.getText().equals(""))
        			{
        				JOptionPane.showMessageDialog(new JFrame(),"Заданы не все параметры !","Сообщение",JOptionPane.ERROR_MESSAGE);
        			    error = true;
        			}
        			else
        			{
        				int Element = Integer.parseInt(jtf5.getText());
        				int Pin = Integer.parseInt(jtf7.getText());
        				String str = new String("");
        				String Temp[];
        				for (int i=0;i<infoList.size();i++)
        				{
        					if ((Element == infoList.get(i).firstNumb && Pin == infoList.get(i).firstPin) ||
        					    (Element == infoList.get(i).secondNumb && Pin == infoList.get(i).secondPin))
        					{
        						str = str + Integer.toString(infoList.get(i).circuit-1) + " ";
        					}
        				}
        				if (str.equals(""))
        				{
        					JOptionPane.showMessageDialog(new JFrame(),"Такого элемента и/или контакта не существует !","Сообщение",JOptionPane.ERROR_MESSAGE);
            			    error = true;
        				}
        				else
        				{
            				Temp = str.split("\\s+");
            				myList = new int [Temp.length];
            				for (int i=0;i<myList.length;i++)
            				myList[i] = Integer.parseInt(Temp[i]);
        				}
        			}
        		}
        		else
        		{
        			if (jtf6.getText().equals("") || jtf8.getText().equals("") || jtf9.getText().equals(""))
        			{
        				JOptionPane.showMessageDialog(new JFrame(),"Заданы не все параметры !","Сообщение",JOptionPane.ERROR_MESSAGE);
        			    error = true;
        			}
        			else
        			{
        				int Element = Integer.parseInt(jtf6.getText());
        				int start = Integer.parseInt(jtf8.getText());
        				int end = Integer.parseInt(jtf9.getText());
        				if (start >= end)
        				{
        					JOptionPane.showMessageDialog(new JFrame(),"Заданы не верный диапазон !","Сообщение",JOptionPane.ERROR_MESSAGE);
            			    error = true;
        				}
        				else
        				{
        					String str = new String("");
            				String Temp[];
            				for (int i=0;i<infoList.size();i++)
            				{
            					if ((Element == infoList.get(i).firstNumb && start <= infoList.get(i).firstPin && end >= infoList.get(i).firstPin) ||
            					    (Element == infoList.get(i).secondNumb && start <= infoList.get(i).secondPin && end >= infoList.get(i).secondPin))
            					{
            						str = str + Integer.toString(infoList.get(i).circuit-1) + " ";
            					}
            				}
            				if (str.equals(""))
            				{
            					JOptionPane.showMessageDialog(new JFrame(),"Такого элемента и/или контакта не существует !","Сообщение",JOptionPane.ERROR_MESSAGE);
                			    error = true;
            				}
            				else
            				{
                				Temp = str.split("\\s+");
                				myList = new int [Temp.length];
                				for (int i=0;i<myList.length;i++)
                				myList[i] = Integer.parseInt(Temp[i]);
            				}
        				}
        			}
        			
        		}
        	}
        	if (!error)
        	{
        		JPanel pane = ((JPanel) tabPane.getComponentAt(tabPane.getSelectedIndex()));
        		DiagramInfo di = obj.get(tabPane.getSelectedIndex());
        	    Chart cc = new Chart(di.protocol,di.info,"ВРЕМЕННЫЕ ДИАГРАММЫ","ВРЕМЯ (ms)","НОМЕРА ЦЕПЕЙ",myList);
        	    obj.remove(tabPane.getSelectedIndex());
        	    obj.add(tabPane.getSelectedIndex(),new DiagramInfo (cc,di.protocol,di.info));
        	    infoList = cc.getPinList();
        	    AbstractTableModel atm = (AbstractTableModel) t.getModel();
                atm.fireTableDataChanged();
        	    pane.removeAll();
        	    pane.add(cc.getChart());
        	    pane.add(cc.getVerticalScrollBar());
        	    pane.add(cc.getHorizontalScrollBar());
        	    pane.updateUI();
        	}
        }	
        else
        if (command.equals ("Сохранить диаграмму"))
        {

        }	
        else	
        if (command.equals ("Выход"))
        {
        	System.exit(0);
        }	
        else
        if (command.equals ("О программе..."))
        {
        	new About ();
        }	
	}
    
    public static void setPaneIndex (int ind)
    {
    	if (ind >= 0) paneIndex = ind;
    }

    public static void main(String[] args)
	{
		SwingUtilities.invokeLater (new Runnable ()
        {
            public void run ()
            {
                new TimeChartGUI("input/protocol_1.txt","input/info_1.txt");
            }
        });
	} // main()
}

